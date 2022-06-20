using MauiBlazorDemonstration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorDemonstration.Data
{
    public class DogService
    {
        private readonly HttpClient httpClient;
        public List<Dog> Dogs;
        public DogService()
        {
            httpClient = new();
        }
        public async Task<List<Dog>> GetDogs(string breedName)
        {
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", "eeIqZ2GtmK491PTqCc9dug==24Ei4B1qwZsbsu59");
            var response = await httpClient.GetAsync($"https://api.api-ninjas.com/v1/dogs?name={breedName}");
            if (response.IsSuccessStatusCode)
            {
                Dogs = await response.Content.ReadFromJsonAsync<List<Dog>>();
            }
            return Dogs;
        }
    }
}
