using GameStore0.FileServer.Interfaces;
using GameStore0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore0.FileServer
{
    public class FileRepo : IFileRepo
    {
        private GamesCollection _gamesCollection;  //и т.п

        public Task<IEnumerable<Game>> GetAllGamesFromFile()
        {
            throw new NotImplementedException();
        }

        public Task<Game> GetGameByIdFromFile(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> ReadFileAsync(string path)
        {
            throw new NotImplementedException();
        }
    }
}
