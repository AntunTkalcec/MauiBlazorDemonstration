using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiBlazorDemonstration.Data;
using MauiBlazorDemonstration.Helpers;
using MauiBlazorDemonstration.Models;
using MauiBlazorDemonstration.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
                    CultureInfo newCulture = new("en-US");
                    Thread.CurrentThread.CurrentCulture = newCulture;
                    Thread.CurrentThread.CurrentUICulture = newCulture;
                    CultureInfo.DefaultThreadCurrentCulture = newCulture;
                    CultureInfo.DefaultThreadCurrentUICulture = newCulture;
                    LanguageHelper.Instance.SetCultureInfo(newCulture);
                    await Shell.Current.DisplayAlert("Done", "Language has been set to English.", "OK");
                    break;
                case 1:
                    await SecureStorage.SetAsync("Language", "hr-HR");
                    CultureInfo newCultureCro = new("hr-HR");
                    Thread.CurrentThread.CurrentCulture = newCultureCro;
                    Thread.CurrentThread.CurrentUICulture = newCultureCro;
                    CultureInfo.DefaultThreadCurrentCulture = newCultureCro;
                    CultureInfo.DefaultThreadCurrentUICulture = newCultureCro;
                    LanguageHelper.Instance.SetCultureInfo(newCultureCro);
                    await Shell.Current.DisplayAlert("Gotovo", "Jezik je postavljen na Hrvatski.", "OK");
                    break;
            }
        }
        public Task LanguageSelected()
        {
            ConfirmIsEnabled = true;
            return Task.CompletedTask;
        }
    }
}
