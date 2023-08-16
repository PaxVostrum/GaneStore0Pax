using GameStore0.API.TempFileRepo;
using GameStore0.FileServer;
using GameStore0.FileServer.Interfaces;
using GameStore0.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameStore0.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ITempFileRepo _fileRepo;
        private readonly IFileReader _fileReader;

        public GameController(ITempFileRepo fileRepo, IFileReader fileReader)
        {
            _fileRepo = fileRepo;
            _fileReader = fileReader;
        }

        // GET: api/<GameController>
        [HttpGet("GetAllLines")]
        public async Task<IActionResult> GetAllLinesFromFile()  //Task<IEnumerable<string>>
        {
            string path = _fileRepo.GetFilePath();

            var result = await _fileReader.ReadFileAsync(path); 

            return Ok(result);
        }


        [HttpGet("GetGames")]
        public async Task<IActionResult> GetGames()  //Task<IEnumerable<string>>
        {
            string path = _fileRepo.GetFilePath();

            var lines = await _fileReader.ReadFileAsync(path);

            var result = _fileReader.GetAllGames(lines).EnumerateAllGames();

            return Ok(result);
        }

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GameController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<GameController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
