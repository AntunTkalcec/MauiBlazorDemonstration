using MauiBlazorDemonstration.Views;

namespace MauiBlazorDemonstration;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(SetupPage), typeof(SetupPage));

        if (Task.Run(async () => await ApplicationIsSetUp()) == Task.FromResult(true))
        {
            CurrentItem = HomeItem;
        }
        else
        {
            CurrentItem = SetupItem;
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