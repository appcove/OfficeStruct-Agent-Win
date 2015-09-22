using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OfficeStruct_Agent_Win.Controls
{
    /// <summary>
    /// Control used to provide a tip on textbox when nothing is written inside
    /// </summary>
    class CueTextBox : TextBox
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage
          (IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private string curText = String.Empty;
        public string CueText
        {
            get { return curText; }
            set
            {
                curText = value;
                SendMessage(Handle, EM_SETCUEBANNER, 0,
                            String.IsNullOrEmpty(value) ? String.Empty : curText);
            }
        }
    }
}
