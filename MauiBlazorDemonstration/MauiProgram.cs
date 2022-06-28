using Microsoft.AspNetCore.Components.WebView.Maui;
using MauiBlazorDemonstration.Data;
using MauiBlazorDemonstration.ViewModels;
using MauiBlazorDemonstration.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MauiBlazorDemonstration;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

		builder.Services.AddSingleton(Connectivity.Current);
		builder.Services.AddSingleton(SecureStorage.Default);
		builder.Services.AddScoped<IDogService, DogService>();

		builder.Services.AddTransient<SetupPageViewModel>();
		builder.Services.AddTransient<SetupPage>();

		builder.Services.AddTransient<HomePage>();
		builder.Services.AddTransient<HomePageViewModel>();

		builder.Services.AddTransient<DogsDisplayNativePage>();
		builder.Services.AddTransient<DogsNativeViewModel>();
		
		builder.Services.AddTransient<DogsDisplayBlazorPage>();
		builder.Services.AddTransient<DogsBlazorViewModel>();

		builder.Services.AddTransient<BaseViewModel>();

		return builder.Build();
	}
}