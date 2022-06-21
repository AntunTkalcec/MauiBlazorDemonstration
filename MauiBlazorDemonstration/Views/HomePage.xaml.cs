using MauiBlazorDemonstration.ViewModels;

namespace MauiBlazorDemonstration.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
	{
		await ConfirmBtn.FadeTo(1.0, 250, Easing.Linear);
	}
}