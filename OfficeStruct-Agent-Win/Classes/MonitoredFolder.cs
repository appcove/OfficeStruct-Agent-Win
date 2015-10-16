using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;
using OfficeStruct_Agent_Win.Annotations;
using Timer = System.Timers.Timer;

namespace OfficeStruct_Agent_Win.Classes
{
    public enum LogLevel
    {
        Off = 0,
        Normal = 1,
        Debug = 2
    }

    public class LogItem
    {
        public DateTime Date;
        public string Message;
        public readonly bool IsValid;

        public LogItem(DateTime date, string message)
        {
            Date = date;
            Message = message;
            IsValid = true;
        }

        public LogItem(string row)
        {
            IsValid = false;

            if (String.IsNullOrEmpty(row)) return;
            var i = row.IndexOf(" ");
            if (i < 0) return;
            i = row.IndexOf(" ", i + 1);
            if (i < 0) return;
            if (!DateTime.TryParseExact(row.Substring(0, i).Trim(),
                "yyyy-MM-dd HH:mm:ss",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out Date))
                return;
            Message = row.Substring(i + 1).Trim();
            IsValid = true;
        }
    }

    public class LogItems : List<LogItem>
    {
        private readonly string folder;
        private readonly int maxItems;

        internal LogItems(string folder, int maxItems = 100)
        {
            this.folder = folder;
            this.maxItems = maxItems;
            Load();
        }

        public LogItem CreateNew(bool writeOnFile, string message, params object[] args)
        {
            var dt = DateTime.Now;
            if (writeOnFile)
            {
                var fi = Directory.CreateDirectory(folder);
                var sfi = fi.CreateSubdirectory(dt.ToString("yyyy-MM"));
                var log = Path.Combine(sfi.FullName, dt.ToString("yyyyMMdd") + ".log");
                if (!File.Exists(log))
                    File.WriteAllLines(log, new string[0]);
                File.AppendAllText(log, String.Format("{0} {1}\n",
                    dt.ToString("yyyy-MM-dd HH:mm:ss"),
                    String.Format(message, args)));
            }

            var li = new LogItem(dt, String.Format(message, args));
            Insert(0, li);
            Purge();
            return li;
        }
        private void Load()
        {
            Clear();
            if (String.IsNullOrEmpty(folder) || !Directory.Exists(folder))
                return;

            var files = Directory.GetDirectories(folder)
                .OrderByDescending(f => f)
                .SelectMany(f => Directory.GetFiles(f, "*.log")
                    .OrderByDescending(file => file));
            foreach (var f in files)
            {
                if (Count >= maxItems) return;
                AddRange(File.ReadAllLines(f)
                    .Select(r => new LogItem(r))
                    .Where(r => r != null && r.IsValid)
                    .OrderByDescending(r => r.Date));
            }
            Purge();
        }

        internal void Purge()
        {
            if (Count > maxItems)
                RemoveRange(maxItems, Count - maxItems);
        }
    }

    public class MonitoredFolder : INotifyPropertyChanged
    {
        private bool checking;
        private Timer tmr;
        private string folder;
        private bool needToStop;
        private Action<MonitoredFolder, LogItem> onNewLogItem;

        public string Folder
        {
            get { return folder; }
            set
            {
                if (value == folder) return;
                folder = value;
                OnPropertyChanged("Folder");
            }
        }
        public string ApiEndpoint;
        public string AuthorizationKey;
        public string ArchiveFolderName;
        public List<string> Exclusions;
        public int DelayBetweenChecks;
        public bool UploadToWebservice;
        public string LogFolderName;
        public LogLevel LogLevel;
        [XmlIgnore]
        public LogItems LogItems;
        internal int MaxLogItems;

        public MonitoredFolder()
        {
            Exclusions = new List<string>();
            ArchiveFolderName = "ARCHIVE";
            LogFolderName = "LOG";
            DelayBetweenChecks = 5;
            UploadToWebservice = true;
            LogLevel = LogLevel.Normal;
        }

        private string GetFileToUpload(string folder)
        {
            return Directory.GetFiles(folder)
                .FirstOrDefault(fname =>
                {
                    var name = Path.GetFileName(fname);
                    return Exclusions.TrueForAll(e => !name.IsLike(e));
                });
        }
        private bool ProcessFile(string upFile)
        {
            try
            {
                if (UploadToWebservice)
                {
                    AddLog(LogLevel.Debug, "Computing SHA for file \"{0}\"", upFile);
                    var sha = upFile.ToSha256();
                    AddLog(LogLevel.Debug, "SHA for file \"{0}\" is {1}", upFile, sha);
                    // 1. Call API to get upload URL
                    AddLog(LogLevel.Normal, "Getting upload url for file \"{0}\"", upFile);
                    // 2. Upload file (if needed)
                    AddLog(LogLevel.Normal, "Uploading file \"{0}\"", upFile);
                }
                // 3. Move file
                var dt = DateTime.Now;
                var folder = Path.Combine(Path.GetDirectoryName(upFile),
                    ArchiveFolderName,
                    dt.ToString("yyyy-MM"));
                Directory.CreateDirectory(folder);
                var targetFile = Path.Combine(folder,
                    String.Format("{0} {1}", dt.ToString("yyyyMMddHHmmss"), Path.GetFileName(upFile)));
                AddLog(LogLevel.Normal, "Moving file \"{0}\" to \"{1}\"", upFile, targetFile);
                File.Move(upFile, targetFile);

                return true;
            }
            catch (Exception e)
            {
                AddLog(LogLevel.Normal, "Error found \"{0}\"", upFile);
                return false;
            }
        }

        internal bool IsValid
        {
            get
            {
                return Folder.IsValidFolder()
                       && (UploadToWebservice == false ||
                           (!String.IsNullOrEmpty(ApiEndpoint)
                            && (ApiEndpoint.StartsWith("http://") || ApiEndpoint.StartsWith("https://"))
                            && !String.IsNullOrEmpty(AuthorizationKey)))
                       && ArchiveFolderName.IsValidFilename()
                       && (LogLevel == LogLevel.Off || LogFolderName.IsValidFilename());
            }
        }
        internal void PerformCheck()
        {
            // If an old check is still in progress we skip this new one
            if (needToStop || checking || !IsValid) return;

            // App is notified the check is in progress
            checking = true;
            try
            {
                // Let's perform the check here
                AddLog(LogLevel.Debug, "Searching for new files in folder \"{0}\"", Folder);
                var upFile = GetFileToUpload(Folder);
                while (upFile != null)
                {
                    if (needToStop) return;
                    if (!ProcessFile(upFile)) return;
                    Thread.Sleep(200);
                    upFile = GetFileToUpload(Folder);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                // Whatever happens, we must notify the app that check is finished
                // so we can perform a new one
                checking = false;
            }
        }
        internal void Start(Action<MonitoredFolder, LogItem> action)
        {
            LogItems = new LogItems(Path.Combine(Folder, LogFolderName));

            if (tmr != null) Stop();
            tmr = new Timer(1000 * DelayBetweenChecks);
            tmr.Elapsed += (sender, args) => PerformCheck();

            needToStop = false;
            onNewLogItem = action;
            tmr.Start();

            AddLog(LogLevel.Debug, "Timer started for folder \"{0}\"", Folder);
        }
        internal void Stop()
        {
            if (tmr == null) return;
            needToStop = true;
            AddLog(LogLevel.Debug, "Waiting for timer to stop for folder \"{0}\"", Folder);
            while (checking)
                Thread.Sleep(200);
            needToStop = false;
            tmr.Stop();
            tmr.Dispose();
            tmr = null;
            AddLog(LogLevel.Debug, "Timer stopped for folder \"{0}\"", Folder);
        }

        internal void AddLog(LogLevel level, string message, params object[] args)
        {
            var li = LogItems.CreateNew(LogLevel != LogLevel.Off && level <= LogLevel, message, args);
            onNewLogItem(this, li);
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
