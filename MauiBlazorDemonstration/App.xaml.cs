using MauiBlazorDemonstration.Helpers;
using MauiBlazorDemonstration.ViewModels;
using MauiBlazorDemonstration.Views;
using System.Diagnostics;
using System.Globalization;

namespace MauiBlazorDemonstration;

public partial class App : Application
{
	public App(BaseViewModel vm)
	{
		InitializeComponent();

		SetCulture();

		MainPage = new AppShell(vm);
    }

	private static async void SetCulture()
	{
		try
		{
			CultureInfo culture;
			string chosenCulture = await SecureStorage.GetAsync("Language");
			if (chosenCulture == "en-US")
			{
				culture = new("en-US");
			}
			else
			{
				culture = new("hr-HR");
			}
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            LanguageHelper.Instance.SetCultureInfo(culture);
        }
		catch (Exception ex)
		{
			Debug.WriteLine("Error working with cultures.");
		}
	}
}
