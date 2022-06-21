using CommunityToolkit.Mvvm.ComponentModel;
using MauiBlazorDemonstration.Data;
using MauiBlazorDemonstration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorDemonstration.ViewModels
{
    [QueryProperty(nameof(Breed), "Breed"), QueryProperty(nameof(Doggo), "Doggo")]
    public partial class DogsNativeViewModel : BaseViewModel
    {
        [ObservableProperty]
        string breed;

        [ObservableProperty]
        public List<Dog> doggo;
        public DogsNativeViewModel()
        {
            var nekaj = Doggo;
            var nekaj2 = Breed;
        }
    }
}
