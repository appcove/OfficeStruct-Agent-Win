using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using OfficeStruct_Agent_Win.Classes;
using OfficeStruct_Agent_Win.Forms;

namespace OfficeStruct_Agent_Win
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{5ACB957B-405A-4093-895C-85F78FB8BF27}");
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmMain());
                mutex.ReleaseMutex();
            }
            else
            {
                // send our Win32 message to notify the running instance
                // to show the message for the user
                NativeMethods.PostMessage(
                    (IntPtr)NativeMethods.HWND_BROADCAST,
                    NativeMethods.WM_ONLYONEINSTANCE,
                    IntPtr.Zero,
                    IntPtr.Zero);
            }
        }
    }
}
