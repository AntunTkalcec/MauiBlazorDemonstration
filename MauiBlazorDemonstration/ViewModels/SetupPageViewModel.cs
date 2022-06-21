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
    public partial class SetupPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ConfirmEnabled))]
        bool confirmIsEnabled;
        public bool ConfirmEnabled => confirmIsEnabled;
        public SetupPageViewModel()
        {
            Title = "Setup";
            ConfirmIsEnabled = false;
        }
        public async Task ConfirmAsync(int btn)
        {
            ConfirmIsEnabled = false;
            Preferences.Set("SetupComplete", "1");

            switch (btn)
            {
                case 0: 
                    await SecureStorage.SetAsync("Language", "en-US");
                    await Shell.Current.DisplayAlert("Done", "Language has been set to English.", "OK");
                    break;
                case 1:
                    await SecureStorage.SetAsync("Language", "hr-HR");
                    await Shell.Current.DisplayAlert("Gotovo", "Jezik je postavljen na Hrvatski.", "OK");
                    break;
            }

            //set language

            //await Shell.Current.GoToAsync(nameof(HomePage), true);
        }
        public Task LanguageSelected()
        {
            ConfirmIsEnabled = true;
            return Task.CompletedTask;
        }
    }
}
