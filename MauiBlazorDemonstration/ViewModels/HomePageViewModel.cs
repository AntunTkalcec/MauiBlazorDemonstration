using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiBlazorDemonstration.Data;
using MauiBlazorDemonstration.Models;
using MauiBlazorDemonstration.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorDemonstration.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        public List<string> DogBreeds { get; set; } = new();

        [ObservableProperty]
        public List<Dog> doggo;

        private readonly DogService dogService;
        private readonly IConnectivity connectivity;

        public HomePageViewModel(DogService dogService, IConnectivity connectivity)
        {
            Title = "Home";
            this.dogService = dogService;
            this.connectivity = connectivity;
            DogBreeds = Breeds.BreedNames;
        }

        [RelayCommand]
        async Task ConfirmAsync(string breed)
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;
            try
            {
                
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Error", "You are not connected to the internet.", "OK");
                    return;
                }

                Doggo = await dogService.GetDogAsync(breed);
                IsBusy = false;
                await Shell.Current.GoToAsync(nameof(DogsDisplayNativePage), true, new Dictionary<string, object>
                {
                    { "Breed", breed }, { "Doggo", Doggo }
                });
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                Doggo = null;
                IsBusy = false;
            }           
        }
    }
}
