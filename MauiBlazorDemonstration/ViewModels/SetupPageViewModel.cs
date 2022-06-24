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
            SetTitle();
            ConfirmIsEnabled = false;
        }

        private async void SetTitle()
        {
            if (await SecureStorage.GetAsync("Language") == "en-US")
            {
                Title = "Settings";
            }
            else
            {
                Title = "Postavke";
            }
        }

        public async Task ConfirmAsync(int btn)
        {
            ConfirmIsEnabled = false;
            Preferences.Set("SetupComplete", "1");

            switch (btn)
            {
                case 0: 
                    await SecureStorage.SetAsync("Language", "en-US");
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
                    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
                    LanguageHelper.Instance.SetCultureInfo(new CultureInfo("en-US"));
                    await Shell.Current.DisplayAlert("Done", "Language has been set to English.", "OK");
                    break;
                case 1:
                    await SecureStorage.SetAsync("Language", "hr-HR");
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("hr-HR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("hr-HR");
                    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("hr-HR");
                    CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("hr-HR");
                    LanguageHelper.Instance.SetCultureInfo(new CultureInfo("hr-HR"));
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
