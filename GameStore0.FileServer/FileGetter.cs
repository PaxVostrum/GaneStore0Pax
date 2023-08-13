using GameStore0.FileServer.Interfaces;
using System.Configuration;

namespace GameStore0.FileServer
{
    public class FileGetter : IFileGetter
    {
        public string GetFilePath(string dirKey, string gamesFileName)
        {
            if (dirKey == null || gamesFileName == null)
                throw new ArgumentNullException($"аргумент неверен");

            string dirPath = ConfigurationManager.AppSettings[dirKey];
            string fileName = ConfigurationManager.AppSettings[gamesFileName];

            return Path.Combine(dirPath, fileName);
        }
    }
}