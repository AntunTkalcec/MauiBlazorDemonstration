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
        bool confirmEnabled;
        public SetupPageViewModel()
        {
            Title = "Setup";
        }
        public async Task ConfirmAsync(int btn)
        {
            await SecureStorage.SetAsync("SetupComplete", "1");

            //set language

            Application.Current.MainPage = new AppShell();
        }
        public Task LanguageSelected()
        {
            confirmEnabled = true;
            return Task.CompletedTask;
        }
    }
}
