using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore0.Client.Models;

namespace GameStore0.Client.TempServ;
public class TempFileRepo
{
    private string _path;
    public TempFileRepo(string path) => _path = path;

    public async Task<GamesCollection> ReadGamesFromFile()
    {
        GamesCollection games = new();
        try
        {
            using StreamReader sr = File.OpenText(_path); //StreamReader(_path);
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