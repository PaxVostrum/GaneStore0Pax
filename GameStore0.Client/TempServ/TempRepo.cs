using GameStore0.Models;

namespace GameStore0.Client.TempServ;

public class TempRepo
{//д.б статическим ибо при переходе м/ду страницами и при новых добавл-ях была одна и та же коллекция
    public static GamesCollection GamesCollection { get; set; } = GetInitialGamesCollection();

    public static GamesCollection GetInitialGamesCollection()
    {
        GamesCollection games = new();
        games.AddToGamesCollection(new Game(1, "Mario", 5.5m)); // , DateTime.UtcNow, Genre.Sport));
        games.AddToGamesCollection(new Game(2, "TMNT", 15.5m)); // , DateTime.UtcNow, Genre.RPG));
        games.AddToGamesCollection(new Game(3, "Tetris", 2.5m)); // , DateTime.UtcNow, Genre.Strategy));

        return games;
    }

    public Game GetGameById(int id)
    {
        return GamesCollection.EnumerateAllGames().FirstOrDefault(g => g.Id == id) ??
            throw new ArgumentException($"Нет игр по данному id:{id}");
    }

    public void UpdateGame(Game game)
    {
        var gameToUpd = GetGameById(game.Id);

        gameToUpd.Name = game.Name;
        gameToUpd.Price = game.Price;
        gameToUpd.ReleaseDate = game.ReleaseDate;
        gameToUpd.Genre = game.Genre;
    }


    //этот можно и не статический
    public void AddGameToGames(GamesCollection games, Game game)
    {
        int maxId = games.EnumerateAllGames().Max(g => g.Id);
        game.Id = ++maxId;

        games.AddToGamesCollection(game);
    }

    public void DeleteGame(GamesCollection games, int Id)
    {
        var gameToDel = GetGameById(Id);

        games.RemoveFromGamesCollection(gameToDel);
    }

}