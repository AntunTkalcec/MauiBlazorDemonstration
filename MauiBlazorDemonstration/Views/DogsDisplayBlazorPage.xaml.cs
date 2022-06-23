using CommunityToolkit.Mvvm.ComponentModel;
using MauiBlazorDemonstration.Models;
using MauiBlazorDemonstration.ViewModels;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace MauiBlazorDemonstration.Views;


public partial class DogsDisplayBlazorPage : ContentPage
{
	readonly DogsBlazorViewModel viewmodel;
    public DogsDisplayBlazorPage(DogsBlazorViewModel vm)
	{
		InitializeComponent();
		BindingContext = viewmodel = vm;
	}
	protected override void OnAppearing()
	{       
        base.OnAppearing();
		RootComp.Parameters = new Dictionary<string, object>()
		{
			{ "Doggo", viewmodel.Doggo }, { "Breed", viewmodel.Breed }
		};
		//BlazorWebView blazorView = new()
		//{
		//	HostPage = "wwwroot/index.html",

		//      };
		//RootComponent RootComp = new()
		//{
		//	Selector = "#app",
		//	ComponentType = typeof(Razor.Pages.Dog),
		//	Parameters = new Dictionary<string, object>()
		//	{
		//		{ "Doggo", viewmodel.Doggo }
		//	}
		//};

		//blazorView.RootComponents.Add(RootComp);

		//Stack.Children.Add(blazorView);
	}
}