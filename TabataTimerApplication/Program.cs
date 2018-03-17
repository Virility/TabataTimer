using System;
using System.IO;
using System.Windows.Forms;
using TabataTimerApplication.Core.Helpers;
using TabataTimerApplication.UI.Forms;

namespace TabataTimerApplication
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

            INIFile configurationFile = null;
            if (args.Length != 0 && File.Exists(args[0]))
                configurationFile = new INIFile(args[0]);
            else
            {
                var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var configurationFilePath = Path.Combine(desktopPath, "default.ini");

                if (File.Exists(configurationFilePath))
                    configurationFile = new INIFile(configurationFilePath);
            }
            Application.Run(new MainForm(configurationFile));
        }
    }
}