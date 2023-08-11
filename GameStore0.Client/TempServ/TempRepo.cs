using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore0.Client.Models;

namespace GameStore0.Client.TempServ;

public class TempRepo
{
    public GamesCollection games { get; }

    public TempRepo()
    {
        games = SetInitialGamesCollection();
    }
    public GamesCollection SetInitialGamesCollection()
    {
        games.AddToGamesCollection(new Game(1, "Mario", 5.5m));
        games.AddToGamesCollection(new Game(2, "TMNT", 15.5m));
        games.AddToGamesCollection(new Game(3, "Tetris", 2.5m));

        return games;
    }

    public async Task AddGameToGames(Game game)
    {
        games.AddToGamesCollection(game);
    }
}