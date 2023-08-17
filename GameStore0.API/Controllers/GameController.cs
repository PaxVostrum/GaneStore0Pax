using GameStore0.API.Controllers;
using GameStore0.API.TempFileRepo;
using GameStore0.FileServer;
using GameStore0.FileServer.InMemoryData;
using GameStore0.FileServer.Interfaces;
using GameStore0.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameStore0.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase //USES FILE
    {
        private readonly IMemoryRepo _repo;

        private GamesCollection _gamesCollection;

        public GameController(IMemoryRepo repo)  //ITempFileRepo fileRepo, IFileReader fileReader)
        {
            _repo = repo;
            RefreshData();
        }

        private void RefreshData()
        {
            _gamesCollection = MemoryRepo.GamesCollection;
        }


        [HttpGet("GetAllGames")]
        public async Task<IActionResult> GetAllGames()  //Task<IEnumerable<string>>
        {
            var result = _gamesCollection.EnumerateAllGames();

            return Ok(result);
        }

        // GET api/<GameController>/5
        [HttpGet("GetGameById/{id}")]
        public async Task<IActionResult> GetGameById(int id)
        {
            var result = _repo.GetGameById(id);
            if (result is null)
            {
                return NotFound($"game at id{id} not found");
            }
            return Ok(result);
        }

        // POST api/<GameController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Game game) // 
        {
            //int was = MemoryRepo.GetInitialGamesCollection().Count(); 
            if (game is null)
                return BadRequest();

            _repo.AddGameToGames(MemoryRepo.GamesCollection, game);
            RefreshData();
            return Ok("done!");
        }


        // PUT api/<GameController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Game game)
        {

        }

        // DELETE api/<GameController>/5
        [HttpDelete("DeleteGame/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _repo.DeleteGame(MemoryRepo.GamesCollection, id);
            RefreshData();
            return Ok("done!");
        }
    }
}


//private readonly ITempFileRepo _fileRepo;
//private readonly IFileReader _fileReader;
//private string _path;

//private GamesCollection _gamesCollection;  //IEnumerable<Game> //Чтоб 2жды не читать из файла


//public GameController(ITempFileRepo fileRepo, IFileReader fileReader)
//{
//    _fileRepo = fileRepo;
//    _fileReader = fileReader;
//    SetUpFilePath();

//    Task.Run(async () => await GetInitailData());
//}
//private void SetUpFilePath() => _path = _fileRepo.GetFilePath();


//private async Task GetInitailData()
//{
//    var lines = await _fileReader.ReadFileAsync(_path);

//    _gamesCollection = _fileReader.GetAllGames(lines);
//}


//// GET: api/<GameController>
//[HttpGet("GetAllLines")]
//public async Task<IActionResult> GetAllLinesFromFile()  //Task<IEnumerable<string>>
//{
//    var result = await _fileReader.ReadFileAsync(_path);

//    return Ok(result);
//}


//[HttpGet("GetGames")]
//public async Task<IActionResult> GetGames()  //Task<IEnumerable<string>>
//{
//    //var lines = await _fileReader.ReadFileAsync(_path);
//    if (_gamesCollection is null)
//        await GetInitailData();

//    var result = _gamesCollection.EnumerateAllGames(); //_fileReader.GetAllGames(lines).EnumerateAllGames();

//    return Ok(result);
//}

//// GET api/<GameController>/5
//[HttpGet("GetGameById/{id}")]
//public async Task<IActionResult> GetGameById(int id)
//{
//    if (_gamesCollection is null)
//        await GetInitailData();

//    var result = _gamesCollection.EnumerateAllGames().FirstOrDefault(g => g.Id == id);

//    return Ok(result);
//}