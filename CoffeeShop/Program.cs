﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CoffeeShop
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FMainMenu());
            //Application.Run(new FRevenue());
        }

        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}