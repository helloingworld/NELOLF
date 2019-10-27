using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NELOLF
{
    public partial class MainForm : Form
    {
        private MenuItem drivesMenuItem;
        private List<string> filesList;

        public MainForm()
        {
            InitializeComponent();

            filesList = new List<string>();

            addMainMenu();
            SetWindowTheme(this.filesListView.Handle, "Explorer", null);

        }


        private void findAddFiles(string drive)
        {
            this.Text = "NELOLF - Scanning...";
            this.drivesMenuItem.Enabled = false;
            this.filesListView.VirtualListSize = 0;
            this.filesList.Clear();
            
            //ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", "/c dir /b /s x:\\")
            //{
            //    //WorkingDirectory = "t:\\",
            //    UseShellExecute = false,
            //    CreateNoWindow = true,
            //    RedirectStandardOutput = true
            //};

            Process process = new Process();
            //process.StartInfo = startInfo;
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/c dir /b /s {drive}";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            //process.StartInfo.WorkingDirectory = "T:\\";
            process.EnableRaisingEvents = true;
            process.SynchronizingObject = this;
            process.Exited += new EventHandler(Process_Exited);

            process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                //Debug.WriteLine(e.Data);
                if (!string.IsNullOrWhiteSpace(e.Data))
                    filesList.Add(e.Data);
            });

            process.Start();
            process.BeginOutputReadLine();
            //process.WaitForExit();

            
        }

        private void Process_Exited(object sender, System.EventArgs e)
        {
            Invoke(new Action(() =>
            {
                this.filesListView.VirtualListSize = this.filesList.Count;
                this.Text = $"NELOLF - {this.filesList.Count:n0} files";
                this.drivesMenuItem.Enabled = true;
                //this.filesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                //this.filesListView.Columns[0].Width = -1;
            }));
        }

        private void filesListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = new ListViewItem(this.filesList[e.ItemIndex]);
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            //this.findAddFiles("C:\\");
        }

        private void addMainMenu()
        {

            this.Menu = new MainMenu();
            MenuItem fileMenu = new MenuItem("&File");
            this.Menu.MenuItems.Add(fileMenu);
            fileMenu.MenuItems.Add(new MenuItem("E&xit", (o, e) => { this.Close();  }));

            this.drivesMenuItem = new MenuItem("&Drives");
            this.Menu.MenuItems.Add(this.drivesMenuItem);
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                MenuItem driveMenuItem = new MenuItem(d.Name);
                driveMenuItem.Click += DriveMenuItem_Click;
                this.drivesMenuItem.MenuItems.Add(driveMenuItem);
            }

            MenuItem helpMenu = new MenuItem("&Help");
            this.Menu.MenuItems.Add(helpMenu);
        }

        private void DriveMenuItem_Click(object sender, EventArgs e)
        {
            this.findAddFiles((sender as MenuItem).Text);
        }

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        private void filesListView_SizeChanged(object sender, EventArgs e)
        {
            //this.filesListView.Columns[0].Width = this.filesListView.Width - 100;
        }

        /// <summary>
        /// Starts a new process and opens the location of the specified file in Explorer and selects it.
        /// </summary>
        /// <param name="fileName">The name of the file to be opened.</param>
        /// <returns>The process object that was used to open the file.</returns>
        public static Process Explore(string fileName)
        {
            return (!string.IsNullOrEmpty(fileName)) ?
                Process.Start("explorer.exe", "/select,\"" + fileName + "\"") : null;
        }

        private void filesListView_DoubleClick(object sender, EventArgs e)
        {
            Explore(this.filesList[this.filesListView.SelectedIndices[0]]);
        }
    }
}
