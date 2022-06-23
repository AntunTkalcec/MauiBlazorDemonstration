using MauiBlazorDemonstration.Views;

namespace MauiBlazorDemonstration;

public partial class App : Application
{
	public App(AppShell shell)
	{
		InitializeComponent();

        MainPage = shell;
    }
}
