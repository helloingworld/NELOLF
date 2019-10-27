// <copyright file="MainForm.cs" company="helloing.world">
// Copyright (c) helloing.world. All rights reserved.
// </copyright>
namespace NELOLF
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Forms;

    /// <summary>
    /// The Main Form class.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The list of files (displayed in the virtual mode listview).
        /// </summary>
        private readonly List<string> filesList = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // Required method for designer support
            this.InitializeComponent();

            this.AddMainMenu();

            // "Refresh" the style of the list view
            UiUtils.SetExplorerTheme(this.filesListView.Handle);
        }

        // ********************************************************************
        // Dir Process Functionality & Events
        // ********************************************************************

        /// <summary>
        /// Scans a path by running a dir command process.
        /// </summary>
        /// <param name="path">The path to scan.</param>
        private void ScanPath(string path)
        {
            this.Text = "NELOLF - Scanning...";
            this.drivesMenuItem.Enabled = false;
            this.filesListView.VirtualListSize = 0;
            this.filesList.Clear();

            SysUtils.RunDirProcess(path, this.Process_Exited, this.Process_OutputDataReceived);
        }

        /// <summary>
        /// Add a new file item each time the dir command writes a line to its redirected
        /// StandardOutput stream.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event data.</param>
        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.Data))
            {
                this.filesList.Add(e.Data);
            }
        }

        /// <summary>
        /// Update the files list view and count when the dir command process exits.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Empty event data.</param>
        private void Process_Exited(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                // Update the file count and re-enable the Drives menu items
                this.Text = $"NELOLF - {this.filesList.Count:n0} files";
                this.drivesMenuItem.Enabled = true;

                // Update the files list view virtual mode count
                this.filesListView.VirtualListSize = this.filesList.Count;
            }));
        }

        // ********************************************************************
        // Menu Events
        // ********************************************************************

        /// <summary>
        /// Scan a the specified drive when a Drive menu item is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Empty event data.</param>
        private void DriveMenuItem_Click(object sender, EventArgs e)
        {
            this.ScanPath((sender as MenuItem).Text);
        }

        // ********************************************************************
        // Files List View Events
        // ********************************************************************

        /// <summary>
        /// Returns the required ListViewItem for the virtual mode list view.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Event data.</param>
        private void FilesListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = new ListViewItem(this.filesList[e.ItemIndex]);
        }

        /// <summary>
        /// Open item in Windows Explorer on double-click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Empty event data.</param>
        private void FilesListView_DoubleClick(object sender, EventArgs e)
        {
            SysUtils.Explore(this.filesList[this.filesListView.SelectedIndices[0]]);
        }
    }
}
