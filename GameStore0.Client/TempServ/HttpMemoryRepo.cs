using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using GameStore0.Models;

namespace GameStore0.Client.TempServ;
public class HttpMemoryRepo
{
    private readonly HttpClient _httpClient;

    public HttpMemoryRepo(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Game>> GetGames()
    {//читает Json и возвр-ет обратно клиенту
        //https://localhost:7178/api/Game/GetAllGames
        var result = await _httpClient.GetFromJsonAsync<GamesCollection>("api/Game/GetAllGames"); //  /api/Game/GetAllGames
        return result.EnumerateAllGames();
    }

    public async Task<Game> GetGameById(int id)
    {
        return await _httpClient.GetFromJsonAsync<Game>($"api/Game/GetGameById/{id}");
    }

    public async Task DeleteGame(int id)
    {
        await _httpClient.DeleteAsync($"api/Game/DeleteGame/{id}");
    }

}
