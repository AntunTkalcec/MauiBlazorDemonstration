using MauiBlazorDemonstration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorDemonstration.Data
{
    public interface IDogService
    {
        Task<List<Dog>> GetDogAsync(string breedName);
    }
}
