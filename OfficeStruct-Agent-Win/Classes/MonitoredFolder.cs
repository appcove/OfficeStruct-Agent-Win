using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using OfficeStruct_Agent_Win.Annotations;
using Timer = System.Timers.Timer;

namespace OfficeStruct_Agent_Win.Classes
{
    public enum LogLevel
    {
        Off,
        Normal,
        Debug
    }

    public class MonitoredFolder : INotifyPropertyChanged
    {
        private bool checking;
        private Timer tmr;
        private string folder;
        private bool needToStop;

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
        public bool UploadEnabled;
        public string ApiEndpoint;
        public string AuthorizationKey;
        public string ArchiveFolderName;
        public List<string> Exclusions;
        public int DelayBetweenChecks;
        public bool UploadToWebservice;
        public string LogFolderName;
        public LogLevel LogLevel;

        public MonitoredFolder()
        {
            UploadEnabled = true;

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
        private bool UploadFile(string upFile)
        {
            if (!UploadEnabled) return true;
            try
            {
                var sha = upFile.ToSha256();
                // 1. Call API to get upload URL
                // 2. Upload file (if needed)
                // 3. Move file
                var dt = DateTime.Now;
                var folder = Path.Combine(Path.GetDirectoryName(upFile),
                    ArchiveFolderName,
                    dt.ToString("yyyy-MM"));
                Directory.CreateDirectory(folder);
                File.Move(upFile, Path.Combine(folder,
                    String.Format("{0} {1}", dt.ToString("yyyyMMddHHmmss"), Path.GetFileName(upFile))));

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        internal bool IsValid
        {
            get
            {
                return !String.IsNullOrEmpty(Folder)
                       && Directory.Exists(Folder)
                       && (UploadToWebservice == false ||
                           (!String.IsNullOrEmpty(ApiEndpoint)
                            && !String.IsNullOrEmpty(AuthorizationKey)))
                       && ArchiveFolderName.IsValidFilename()
                       && (LogLevel == LogLevel.Off || LogFolderName.IsValidFilename());
            }
        }
        internal void PerformCheck()
        {
            // If an old check is still in progress we skip this new one
            if (needToStop || checking || !UploadEnabled || !IsValid) return;

            // App is notified the check is in progress
            checking = true;
            try
            {
                // Let's perform the check here
                var upFile = GetFileToUpload(Folder);
                while (upFile != null)
                {
                    if (needToStop) return;
                    if (!UploadFile(upFile)) return;
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
        internal void Start()
        {
            if (tmr != null) Stop();
            tmr = new Timer(1000 * DelayBetweenChecks);
            tmr.Elapsed += (sender, args) => PerformCheck();

            needToStop = false;
            tmr.Start();

            Trace.WriteLine(String.Format("Timer started for {0}", Folder));
        }
        internal void Stop()
        {
            if (tmr == null) return;
            needToStop = true;
            while (checking)
                Thread.Sleep(200);
            needToStop = false;
            tmr.Stop();
            tmr.Dispose();
            tmr = null;
            Trace.WriteLine(String.Format("Timer stopped for {0}", Folder));
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
