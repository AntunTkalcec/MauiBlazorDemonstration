using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiBlazorDemonstration.Data;
using MauiBlazorDemonstration.Models;
using MauiBlazorDemonstration.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorDemonstration.ViewModels
{
    [QueryProperty(nameof(Breed), "Breed"), QueryProperty(nameof(ChosenDoggo), "Doggo")]
    public partial class DogsNativeViewModel : BaseViewModel
    {
        [ObservableProperty]
        string breed;

        [ObservableProperty]
        public Dog chosenDoggo;
        public DogsNativeViewModel()
        {

        }

        [RelayCommand]
        async Task ShowDoggoUsingBlazorAsync()
        {
            await Shell.Current.GoToAsync(nameof(DogsDisplayBlazorPage), true, new Dictionary<string, object>
            {
                { "Doggo", ChosenDoggo }, { "Breed", Breed }
            });
        }
    }
}
