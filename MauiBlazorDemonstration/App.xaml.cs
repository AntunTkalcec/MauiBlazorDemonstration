using MauiBlazorDemonstration.Views;

namespace MauiBlazorDemonstration;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new AppShell();
    }
}
