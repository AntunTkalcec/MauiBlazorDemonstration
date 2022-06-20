﻿using MauiBlazorDemonstration.Views;

namespace MauiBlazorDemonstration;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        if (Task.Run(async () => await ApplicationIsSetUp()) == Task.FromResult(true))
        {
            MainPage = new AppShell();
        }
        else
        {
            MainPage = new SetupPage();
        }
    }

    private static async Task<bool> ApplicationIsSetUp()
    {
        try
        {
            string setup = await SecureStorage.GetAsync("SetupComplete");

            if (setup == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            // Possible that device doesn't support secure storage on device. 
            return false;
        }
    }
}
