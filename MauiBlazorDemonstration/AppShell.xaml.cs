using MauiBlazorDemonstration.ViewModels;
using MauiBlazorDemonstration.Views;

namespace MauiBlazorDemonstration;

public partial class AppShell : Shell
{
	public AppShell(BaseViewModel vm)
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(SetupPage), typeof(SetupPage));
        Routing.RegisterRoute(nameof(DogsDisplayNativePage), typeof(DogsDisplayNativePage));
        Routing.RegisterRoute(nameof(DogsDisplayBlazorPage), typeof(DogsDisplayBlazorPage));
        BindingContext = vm;
    }
}