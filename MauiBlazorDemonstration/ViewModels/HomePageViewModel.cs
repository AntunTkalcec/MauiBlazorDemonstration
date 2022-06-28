using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiBlazorDemonstration.Data;
using MauiBlazorDemonstration.Models;
using MauiBlazorDemonstration.Views;

namespace MauiBlazorDemonstration.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        public List<string> DogBreeds { get; set; } = new();

        [ObservableProperty]
        public List<Dog> doggos;

        [ObservableProperty]
        private Dog doggo;

        private readonly IDogService dogService;
        private readonly IConnectivity connectivity;

        public HomePageViewModel(IDogService dogService, IConnectivity connectivity)
        {
            ActivityColor = Colors.Transparent;
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
            ActivityColor = Color.FromArgb("#3AA0B4");
            try
            {               
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Error", "You are not connected to the internet.", "OK");
                    return;
                }

                Doggos = await dogService.GetDogAsync(breed);
                Doggo = Doggos[0];
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
                Doggos = null;
                Doggo = null;
                ActivityColor = Colors.Transparent;
                IsBusy = false;
            }           
        }
    }
}
