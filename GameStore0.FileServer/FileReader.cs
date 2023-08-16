using GameStore0.FileServer.Interfaces;
using GameStore0.Models;
using System.Globalization;

namespace GameStore0.FileServer
{
    public class FileReader : IFileReader
    {
        public async Task<IEnumerable<string>> ReadFileAsync(string path)
        {
            if (!File.Exists(path))
            {
                throw new IOException($"File {path} doesn't exist");
            }
            using StreamReader sr = new StreamReader(path);
            var resultList = new List<string>();
            while (!sr.EndOfStream)
            {
                string line = await sr.ReadLineAsync();
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                resultList.Add(line);
            }

            return resultList;
        }


        public GamesCollection GetAllGames(IEnumerable<string> lines)
        {
            GamesCollection games = new();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                Game game = ParseLineIntoGame(line);
                games.AddToGamesCollection(game);
            }
            return games;
        }

        private Game ParseLineIntoGame(string line)
        {
            string[] fields = line.Split(';');
            if (fields.Length != 3)
                throw new Exception($"Cannot parse order line: Text is {line}");

            int id = int.Parse(fields[0]);
            string name = fields[1];
            decimal price = decimal.Parse(fields[2], CultureInfo.InvariantCulture);

            return new Game(id, name, price, DateTime.Now);  //ДАТА тут короче);
        }
    }
}
