using GameStore0.FileServer.Interfaces;
using System.Configuration;

namespace GameStore0.FileServer
{
    public class FileGetter : IPathGetter //для Консольного и WPF приложения, для ASP же исп-ем на местах appsettings.json не App.confing
    {
        public string GetFilePath(string dirKey, string gamesFileName)
        {
            if (dirKey == null || gamesFileName == null)
                throw new ArgumentNullException($"неверный путь к файлу данных");

            string dirPath = ConfigurationManager.AppSettings[dirKey];
            string fileName = ConfigurationManager.AppSettings[gamesFileName];

            return Path.Combine(dirPath, fileName);
        }
    }
}