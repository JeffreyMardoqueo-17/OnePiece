using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using OnePieceWorld.Models;
using System.Text.Json;

namespace OnePieceWorld.service
{
    public class CrewService : ICrewService
    {
        private readonly HttpClient ? _httpClient;
        //API A LA QUE LLAMARE LOS CREW
        private string API = "https://api.api-onepiece.com/v2/crews/en";
        
        public CrewService (HttpClient httpClient){
            _httpClient = httpClient;
        }

        //metodo para traer opedir todos
        public async Task<List<Crew>> GetCrewsAsync(){
            var response = await _httpClient.GetAsync(API);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var crews = JsonSerializer.Deserialize<List<Crew>>(json, new JsonSerializerOptions{
                    PropertyNameCaseInsensitive = true
                });
                return crews ?? new List<Crew>();
            }
            return new List<Crew>();
        }
    }
}