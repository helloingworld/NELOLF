// <copyright file="UiUtils.cs" company="helloing.world">
// Copyright (c) helloing.world. All rights reserved.
// </copyright>
namespace NELOLF
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// User interface utility methods.
    /// </summary>
    internal static class UiUtils
    {
        /// <summary>
        /// Set the "Explorer" set of visual style information.
        /// </summary>
        /// <param name="handle">Handle to the control whose visual style information is to be changed.</param>
        public static void SetExplorerTheme(IntPtr handle)
        {
            NativeMethods.SetWindowTheme(handle, "Explorer", null);
        }

        /// <summary>
        /// Required Windows native methods definitions.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed.")]
        internal static class NativeMethods
        {
            [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
            public static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);
        }
    }
}
