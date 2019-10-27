// <copyright file="MainForm.Temp.cs" company="helloing.world">
// Copyright (c) helloing.world. All rights reserved.
// </copyright>
namespace NELOLF
{
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Main form class.
    /// </summary>
    public partial class MainForm
    {
        private MenuItem drivesMenuItem;

        private void AddMainMenu()
        {
            this.Menu = new MainMenu();
            MenuItem fileMenu = new MenuItem("&File");
            this.Menu.MenuItems.Add(fileMenu);
            fileMenu.MenuItems.Add(new MenuItem("E&xit", (o, e) => { this.Close(); }));

            this.drivesMenuItem = new MenuItem("&Drives");
            this.drivesMenuItem.Name = "drivesMenuItem";
            this.Menu.MenuItems.Add(this.drivesMenuItem);
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                MenuItem driveMenuItem = new MenuItem(d.Name);
                driveMenuItem.Click += this.DriveMenuItem_Click;
                this.drivesMenuItem.MenuItems.Add(driveMenuItem);
            }

            MenuItem helpMenu = new MenuItem("&Help");
            this.Menu.MenuItems.Add(helpMenu);
        }
    }
}
