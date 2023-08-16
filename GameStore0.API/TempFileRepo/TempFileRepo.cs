using GameStore0.FileServer.Interfaces;
using GameStore0.Models;

namespace GameStore0.API.TempFileRepo
{//Почему сдесь а не в отд-й библ-ке - т.к appsettings.json тут
    public class TempFileRepo : ITempFileRepo 
    {
        private readonly IConfiguration _config;
        //private readonly IPathGetter _fileGetter;
        //private readonly IFileReader _fileReader;

        private const string dataFilePath = "GamesDataFile:gamesDataPath";
        private const string datafileName = "GamesDataFile:gamesFileName";
        //private string path;
        //public TempFileRepo(string path) => this.path = path;
        public TempFileRepo(IConfiguration config)//, IPathGetter fileGetter, IFileReader fileReader)
        {
            _config = config;
            //_fileGetter = fileGetter;
            //_fileReader = fileReader;
        }

        public string GetFilePath()
        {
            string dirPath = _config.GetValue<string>(dataFilePath);  
            string fileName = _config.GetValue<string>(datafileName);
            if (string.IsNullOrWhiteSpace(dirPath) || string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException($"неверный путь к файлу данных");
            }

            string path = Path.Combine(dirPath, fileName);
            if (!File.Exists(path))
            {
                throw new IOException($"File at{path} doesn't exists");
            }

            return path;
        }
    }
}
