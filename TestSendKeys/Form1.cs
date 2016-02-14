using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
// process is defined in the library below
using System.Diagnostics;
// Using DllInport is defined in the process below
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSendKeys
{
    public partial class Form1 : Form
    {
        [DllImport("User32.dll")]
        public static extern int SetForegroundWindow(IntPtr point);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNotepadSend_Click(object sender, EventArgs e)
        {
            Process p = Process.Start("notepad.exe");
            p.WaitForInputIdle();
            IntPtr h = p.MainWindowHandle;
            SetForegroundWindow(h);
            SendKeys.SendWait("It was the best of times, it was the worst of times.");
            IntPtr processFoundWindow = p.MainWindowHandle;
        }
    }
}
