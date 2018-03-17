using System;
using System.IO;
using System.Windows.Forms;
using KegelTimerApplication.Core.Models;
using KegelTimerApplication.UI.Forms;

namespace KegelTimerApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IniFile configurationFile = null;
            if (args.Length != 0 && File.Exists(args[0]))
                configurationFile = new IniFile(args[0]);
            else
            {
                if (File.Exists(Config.ConfigurationFilePath))
                    configurationFile = new IniFile(Config.ConfigurationFilePath);
            }
            Application.Run(new MainForm(configurationFile));
        }
    }
}