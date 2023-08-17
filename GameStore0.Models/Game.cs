using System.ComponentModel.DataAnnotations;

namespace GameStore0.Models
{
    public class Game
    {
        public int Id { get; set; }
       // [Required]
       // [StringLength(50)]
        public string Name { get; set; } //public required string Name { get; init} - какая-то фишка required -чтоб незя было объ-т создать без него, но у нас CTOR -и так не даст
       // [Range(1, 101)]
        public decimal Price { get; set; }
        // public string Genre { get; init; }
        public DateTime ReleaseDate { get; set; }

        public Genre? Genre { get; set; }

        public Game(int id, string name, decimal price, DateTime date, Genre? genre = null) //string genre, DateTime date
        {
            Id = id; Name = name; Price = price;
            ReleaseDate = date;
            Genre = genre;
        }
    }
}