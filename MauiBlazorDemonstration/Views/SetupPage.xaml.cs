using MauiBlazorDemonstration.ViewModels;

namespace MauiBlazorDemonstration.Views;

public partial class SetupPage : ContentPage
{
	SetupPageViewModel viewModel;
	int selectedBtn;
	public SetupPage()
	{
		InitializeComponent();
		BindingContext = viewModel = new SetupPageViewModel();
		selectedBtn = int.MinValue;
	}

	private async void EnglishBtnTapped(object sender, EventArgs e)
	{
		_ = EnglishBorder.ScaleTo(1.15, 250, Easing.Linear);
		_ = CroatianBorder.ScaleTo(1, 250, Easing.Linear);
		EnglishBtn.FontAttributes = FontAttributes.Bold;
		CroatianBtn.FontAttributes = FontAttributes.None;
		selectedBtn = 0;
		await viewModel.LanguageSelected();
	}

	private async void CroatianBtnTapped(object sender, EventArgs e)
	{
		_ = CroatianBorder.ScaleTo(1.15, 250, Easing.Linear);
		_ = EnglishBorder.ScaleTo(1.0, 250, Easing.Linear);
		CroatianBtn.FontAttributes = FontAttributes.Bold;
		EnglishBtn.FontAttributes = FontAttributes.None;
		selectedBtn = 1;
        await viewModel.LanguageSelected();
    }
	private async void ConfirmBtnTapped(object sender, EventArgs e)
	{				
		await ConfirmBorder.ScaleTo(0.9, 62, Easing.Linear);
		await ConfirmBorder.ScaleTo(1, 62, Easing.Linear);
		await viewModel.ConfirmAsync(selectedBtn);
		_ = CroatianBorder.Scale = 1;
		_ = EnglishBorder.Scale = 1;
	}
}