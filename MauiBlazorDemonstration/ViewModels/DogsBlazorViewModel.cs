using CommunityToolkit.Mvvm.ComponentModel;
using MauiBlazorDemonstration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorDemonstration.ViewModels
{
    [QueryProperty(nameof(Doggo), "Doggo"), QueryProperty(nameof(Breed), "Breed")]
    public partial class DogsBlazorViewModel : BaseViewModel
    {
        [ObservableProperty]
        Dog doggo;

        [ObservableProperty]
        string breed;

        public DogsBlazorViewModel()
        {
            
        }
    }
}
