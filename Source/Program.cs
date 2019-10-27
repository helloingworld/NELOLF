// <copyright file="Program.cs" company="helloing.world">
// Copyright (c) helloing.world. All rights reserved.
// </copyright>
namespace NELOLF
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// The main program class.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
