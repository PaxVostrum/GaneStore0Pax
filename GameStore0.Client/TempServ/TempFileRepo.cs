using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore0.Client.Models;
using GameStore0.FileServer;
using GameStore0.FileServer.Interfaces;

namespace GameStore0.Client.TempServ;
public class TempFileRepo 
{
    private readonly IConfiguration _config;
    private readonly IFileGetter _fileGetter;
    private readonly IFileReader _fileReader;

    private const string dataFilePath = "GamesDataFile:gamesDataPath";
    private const string datafileName = "GamesDataFile:gamesFileName";
    //private string path;
    //public TempFileRepo(string path) => this.path = path;
    public TempFileRepo(IConfiguration config,IFileGetter fileGetter, IFileReader fileReader)
    {
        _config = config;
        _fileGetter = fileGetter;
        _fileReader = fileReader;
    }
    public async Task<GamesCollection> ReadGamesFromFile()
    {
        GamesCollection games = new();

        string dirPath = _config.GetValue<string>(dataFilePath);  // fileGetter.GetFilePath("gamesDataPath", "gamesFileName");
        string fileName = _config.GetValue<string>(datafileName);
        if (string.IsNullOrWhiteSpace(dirPath)||string.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentNullException($"неверный путь к файлу данных");
        }
        string path = @"C:\Proj\gamesData.csv";//Path.Combine(dirPath, fileName); //_fileGetter.GetFilePath(dirPath, fileName);

        if (!File.Exists(path))
        {
            throw new IOException($"File {path} doesn't exist");
        }

        try
        {
            using StreamReader sr = new StreamReader(path); //File.OpenText(path); 
            while (!sr.EndOfStream)
            {
                string line = await sr.ReadLineAsync();
                if (string.IsNullOrWhiteSpace(line)) continue;

                Game game = ParseLineIntoGame(line);
                games.AddToGamesCollection(game);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
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
        decimal price = decimal.Parse(fields[2]);

        return new Game(id, name, price);
    }
}