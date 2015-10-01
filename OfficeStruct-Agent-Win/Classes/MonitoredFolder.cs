using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OfficeStruct_Agent_Win.Classes
{
    public class MonitoredFolder
    {
        public string Folder;
        public bool UploadEnabled;
        public string ApiEndpoint;
        public string AuthorizationKey;
        public string ArchiveFolderName;
        public List<string> Exlusions;
        public int DelayBetweenChecks;

        public MonitoredFolder()
        {
            Exlusions = new List<string>();
            ArchiveFolderName = "ARCHIVE";
            DelayBetweenChecks = 10;
            UploadEnabled = true;
        }

        public bool IsValid
        {
            get
            {
                return !String.IsNullOrEmpty(Folder)
                    && Directory.Exists(Folder)
                    && !String.IsNullOrEmpty(ApiEndpoint)
                    && !String.IsNullOrEmpty(AuthorizationKey)
                    && !String.IsNullOrEmpty(ArchiveFolderName);
            }
        }

    }
}
