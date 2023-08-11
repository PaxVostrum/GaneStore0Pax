namespace GameStore0.Client.Models;
public class Game
{
    public int Id { get; init; }
    public string Name { get; init; } //public required string Name { get; init} - какая-то фишка required -чтоб незя было объ-т создать без него, но у нас CTOR -и так не даст
    public decimal Price { get; init; }
    // public string Genre { get; init; }
    // public DateTime ReleaseDate { get; init; }

    public Game(int id, string name, decimal price) //string genre, DateTime date
    {
        Id = id; Name = name; Price = price;
        //Genre = genre; ReleaseDate = date;
    }
}