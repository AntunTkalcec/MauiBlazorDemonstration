using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorDemonstration.Models
{
    public static class Breeds
    {
        public static List<string> BreedNames 
        { 
            get
            {
                List<string> names = new()
                {
                    "Dalmatian", "Golden retriever", "Japanese Akita", "Chihuahua", "Shiba Inu"
                };
                return names;
            }
        }
    }
}
