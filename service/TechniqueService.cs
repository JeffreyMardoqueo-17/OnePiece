using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnePieceWorld.Models;
using System.Text.Json;

namespace OnePieceWorld.service
{
    public class TechniqueService : ITechnique
    {
        private HttpClient _httpClient;
        private readonly string API = "https://api.api-onepiece.com/v2/luffy-techniques/en";

        public TechniqueService(HttpClient httpClient){
            _httpClient = httpClient;
        }
        public async Task<List<Technique>> GetAsyncTechniques()
        {
            var response = await _httpClient.GetAsync(API);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var techniques = JsonSerializer.Deserialize<List<Technique>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return techniques ?? new List<Technique>();
            }

            // En caso de que la respuesta no sea exitosa, devolvemos una lista vacía
            return new List<Technique>();
        }
    }
}