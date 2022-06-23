using MauiBlazorDemonstration.Views;

namespace MauiBlazorDemonstration;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(SetupPage), typeof(SetupPage));
        Routing.RegisterRoute(nameof(DogsDisplayNativePage), typeof(DogsDisplayNativePage));
        Routing.RegisterRoute(nameof(DogsDisplayBlazorPage), typeof(DogsDisplayBlazorPage));
    }
}