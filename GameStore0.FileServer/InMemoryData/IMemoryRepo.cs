using GameStore0.Models;

namespace GameStore0.FileServer.InMemoryData
{
    public interface IMemoryRepo
    {
        void AddGameToGames(GamesCollection games, Game game);
        void DeleteGame(GamesCollection games, int Id);
        Game GetGameById(int id);
        void UpdateGame(Game game);
    }
}