using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore0.Client.Models
{
    public class GamesCollection
    {
        private List<Game> _games = new();

        public void AddToGamesCollection(Game game) => _games.Add(game);

        public void RemoveFromGamesCollection(Game game)
        {
            var gameToDelete = _games.FirstOrDefault(g => g == game);
            _games.Remove(gameToDelete); //проверь как он удаляет null из коллекции если чё
        }

        public IEnumerable<Game> EnumerateAllGames()
        {
            foreach (var g in _games)
                yield return g;
        }
    }
}