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
			{ "Doggo", viewmodel.Doggo }, { "Breed", viewmodel.Breed }, { "vm", viewmodel.Vm }
		};
	}
}