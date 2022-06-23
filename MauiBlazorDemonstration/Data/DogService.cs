using MauiBlazorDemonstration.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorDemonstration.Data
{
    public class DogService : IDogService
    {
        private readonly HttpClient httpClient;
        public List<Dog> Dog;
        private string apiKey;
        public static IDogService Current { get; }
        public DogService()
        {
            httpClient = new();
            LoadApiAsset();
        }

        private async Task LoadApiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("config.txt");
            using var reader = new StreamReader(stream);
            apiKey = reader.ReadToEnd();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", $"{apiKey}");
        }
        public async Task<List<Dog>> GetDogAsync(string breedName)
        {           
            var response = await httpClient.GetAsync($"https://api.api-ninjas.com/v1/dogs?name={breedName}");
            if (response.IsSuccessStatusCode)
            {
                var dog = await response.Content.ReadAsStringAsync();
                Dog = JsonConvert.DeserializeObject<List<Dog>>(dog);
            }
            return Dog;
        }
    }
}
