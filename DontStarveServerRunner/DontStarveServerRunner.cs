using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DontStarveServerRunner
{
    public partial class DontStarveServerRunner : Form
    {
        public DontStarveServerRunner()
        {
            InitializeComponent();
            labelServerStatus.Text = "Offline";
            labelServerStatus.ForeColor = Color.Red;
        }

        [DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow); //ShowWindow needs an IntPtr

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);

        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                Process process = Process.Start("C:\\Users\\ricar\\Documents\\Klei\\DoNotStarveTogether\\StartDSTServer.bat");
                process.WaitForExit();

                labelServerStatus.Text = "Online";
                labelServerStatus.ForeColor = Color.YellowGreen;
            } catch (Exception)
            {
                labelServerStatus.Text = "Offline";
                labelServerStatus.ForeColor = Color.Red;
            }
        }

        private void buttonStopServer_Click(object sender, EventArgs e)
        {
            IntPtr hWnd; //change this to IntPtr
            Process[] processRunning = Process.GetProcesses();
            foreach (Process pr in processRunning)
            {
                if (pr.ProcessName == "dontstarve_dedicated_server_nullrenderer_x64")
                {
                    try
                    {
                        hWnd = pr.MainWindowHandle; //use it as IntPtr not int
                        ShowWindow(hWnd, 3);
                        SetForegroundWindow(hWnd);

                        SendKeys.Send("c_shutdown{(}{)}{ENTER}");
                        SendKeys.Flush();
                    } finally
                    {
                        labelServerStatus.Text = "Offline";
                        labelServerStatus.ForeColor = Color.Red;
                    }
                }
            }
        }
    }
}
