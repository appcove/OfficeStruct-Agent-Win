using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OfficeStruct_Agent_Win.Classes
{
    /// <summary>
    /// Class to store and retrieve options file.
    /// File is automatically written as a well-formed XML file
    /// and read as a class
    /// </summary>
    public class Options
    {
        private static string fname;
        private bool uploadEnabled;

        public List<MonitoredFolder> Folders;
        public bool ShowNotifications;

        public Options()
        {
            Folders = new List<MonitoredFolder>();
            ShowNotifications = false;
        }

        /// <summary>
        /// This method loads options from file.
        /// If file is not found then a generic options class with default values is created and saved to disk.
        /// </summary>
        /// <param name="filename">Filename to read options from</param>
        /// <returns>Options class read from file or created from scratch</returns>
        public static Options Load(string filename)
        {
            fname = filename;
            // If file exists then the content is read from it and converted from XML
            if (File.Exists(fname))
                try
                {
                    return Xml.FromFile<Options>(fname);
                }
                catch (Exception e)
                {
                    return null;
                }

            // If file does not exist then a generic options class is created and saved
            var opt = new Options();
            opt.Save();
            return opt;
        }
        public void Save(string filename = null)
        {
            Xml.ToFile(this, filename ?? fname);
            fname = filename ?? fname;
        }
    }
}
