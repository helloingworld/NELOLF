// <copyright file="SysUtils.cs" company="helloing.world">
// Copyright (c) helloing.world. All rights reserved.
// </copyright>
namespace NELOLF
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// System utility methods.
    /// </summary>
    internal static class SysUtils
    {
        /// <summary>
        /// Runs a dir command process.
        /// </summary>
        /// <param name="path">The path for the dir command.</param>
        /// <param name="exited">Process exited event handler.</param>
        /// <param name="received">Process data received event handler.</param>
        /// <returns>The dir command process.</returns>
        public static Process RunDirProcess(string path, EventHandler exited, DataReceivedEventHandler received)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/c dir /b /s {path}";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.EnableRaisingEvents = true;
            process.OutputDataReceived += new DataReceivedEventHandler(received);
            process.Exited += new EventHandler(exited);

            process.Start();
            process.BeginOutputReadLine();

            return process;
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
    }
}
