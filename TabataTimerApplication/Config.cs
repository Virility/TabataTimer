using System.IO;
using System.Reflection;

namespace KegelTimerApplication
{
    public static class Config
    {
        private static string _applicationPath;
        public static string ApplicationPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_applicationPath))
                    _applicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                return _applicationPath;
            }
        }

        public static string ConfigurationFilePath => Path.Combine(Config.ApplicationPath, "default.ini");
    }
}