using GameStore0.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore0.FileServer.Interfaces
{
    public interface IFileRepo
    {
        Task<IEnumerable<string>> ReadFileAsync(string path); //чисто строки из файла
        Task<IEnumerable<Game>> GetAllGamesFromFile();
        Task<Game> GetGameByIdFromFile(int id);
    }
}
