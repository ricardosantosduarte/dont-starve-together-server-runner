using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DontStarveServerRunner
{
    public partial class DontStarveServerRunner : Form
    {
        private static String APP_DATA_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static String SERVER_CONFIGURATIONS_FOLDER = "DontStarveTogetherServerRunnerConfig";
        private static String RUNNER_CONFIG = "config.txt";
        private static String DEFAULT_SERVER_LOCATION = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Klei\\DoNotStarveTogether";
        private static String SERVER_NAME = "StartDSTServer.bat";
        private List<Process> shards;
        private int numberOfShards;
        private bool isOnline;
        private String serverLocation;

        [DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

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

            Directory.CreateDirectory(
                Path.Combine(
                    APP_DATA_FOLDER,
                    SERVER_CONFIGURATIONS_FOLDER
                )
            );

            if (!File.Exists(Path.Combine(APP_DATA_FOLDER, SERVER_CONFIGURATIONS_FOLDER, RUNNER_CONFIG)))
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(APP_DATA_FOLDER, SERVER_CONFIGURATIONS_FOLDER, RUNNER_CONFIG), true))
                    outputFile.WriteLine(Path.Combine(DEFAULT_SERVER_LOCATION, SERVER_NAME));
            else
                using (StreamReader outputFile = new StreamReader(Path.Combine(APP_DATA_FOLDER, SERVER_CONFIGURATIONS_FOLDER, RUNNER_CONFIG), true))
                    this.serverLocation = outputFile.ReadLine();

            if (!File.Exists(this.serverLocation))
            {
                this.serverLocation = Path.Combine(DEFAULT_SERVER_LOCATION, SERVER_NAME);
            }

            textBoxServerPath.Text = this.serverLocation;

            this.getAllServerShards();

            if (this.isOnline == true)
                this.setOnlineLabels();
            else
                this.setOfflineLabels();
        }

        private void setOnlineLabels()
        {
            labelServerStatus.Text = "Online";
            labelServerStatus.ForeColor = Color.YellowGreen;
            labelNumberOfShardsValue.Text = this.numberOfShards.ToString();
        }

        private void setOfflineLabels()
        {
            labelServerStatus.Text = "Offline";
            labelServerStatus.ForeColor = Color.Red;
            labelNumberOfShardsValue.Text = this.numberOfShards.ToString();
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

                Process process = Process.Start(this.serverLocation);
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

        private void buttonReloadStatus_Click(object sender, EventArgs e)
        {
            this.getAllServerShards();

            if (this.isOnline)
                this.setOnlineLabels();
            else
                this.setOfflineLabels();
        }

        private void textBoxPath_MouseClick(object sender, MouseEventArgs e)
        {
            this.openFileDialog1 = new OpenFileDialog();
            this.openFileDialog1.InitialDirectory = DEFAULT_SERVER_LOCATION;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                String filePath = openFileDialog1.FileName;

                File.WriteAllText(Path.Combine(APP_DATA_FOLDER, SERVER_CONFIGURATIONS_FOLDER, RUNNER_CONFIG), filePath);
                this.serverLocation = filePath;
                textBoxServerPath.Text = filePath;
            }
        }
    }
}
