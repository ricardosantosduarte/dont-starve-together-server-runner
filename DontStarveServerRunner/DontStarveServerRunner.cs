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
        private List<Process> shards;
        private int numberOfShards;
        private bool isOnline;

        [DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow); //ShowWindow needs an IntPtr

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);

        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();

        public DontStarveServerRunner()
        {
            InitializeComponent();
            this.shards = new List<Process>();
            this.numberOfShards = 0;
            this.isOnline = false;

            this.setOfflineLabels();

            this.getAllServerShards();

            if (this.isOnline == true)
            {
                this.setOnlineLabels();
            }
        }

        private void setOnlineLabels()
        {
            labelServerStatus.Text = "Online";
            labelServerStatus.ForeColor = Color.YellowGreen;
        }

        private void setOfflineLabels()
        {
            labelServerStatus.Text = "Offline";
            labelServerStatus.ForeColor = Color.Red;
        }

        private void getAllServerShards()
        {
            List<Process> processRunning = Process.GetProcesses().ToList();
            List<Process> temp = new List<Process>();

            foreach (Process pr in processRunning)
                if (pr.ProcessName.Equals("dontstarve_dedicated_server_nullrenderer_x64") || pr.ProcessName.Equals("dontstarve_dedicated_server_nullrenderer"))
                    temp.Add(pr);

            this.shards = temp;
            this.numberOfShards = this.shards.Count;

            if (this.numberOfShards == 0)
                this.isOnline = false;
            else
                this.isOnline = true;
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                this.getAllServerShards();

                if (this.isOnline == true)
                {
                    MessageBox.Show("Server already online");
                    return;
                }

                Process process = Process.Start($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Klei\\DoNotStarveTogether\\StartDSTServer.bat");
                process.WaitForExit();

                this.setOnlineLabels();
            } catch (Exception)
            {
                this.setOfflineLabels();
            }
        }

        private void buttonStopServer_Click(object sender, EventArgs e)
        {
            IntPtr hWnd;

            this.getAllServerShards();

            foreach (Process shard in shards)
            {
                try
                {
                    hWnd = shard.MainWindowHandle;
                    ShowWindow(hWnd, 3);
                    SetForegroundWindow(hWnd);

                    SendKeys.Send("c_shutdown{(}{)}{ENTER}");
                    SendKeys.Flush();

                    shard.WaitForExit();
                    this.numberOfShards--;
                } 
                catch {
                    MessageBox.Show("Error closing server, please shut it down manually!");
                }
            }

            if (numberOfShards == 0)
            {
                this.setOfflineLabels();
            }
            else
            {
                labelServerStatus.Text = "Error closing the server";
                labelServerStatus.ForeColor = Color.Orange;
            }
        }
    }
}
