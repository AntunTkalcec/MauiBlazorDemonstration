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
	}

	private async void EnglishBtnTapped(object sender, EventArgs e)
	{
		_ = EnglishBtn.ScaleTo(1.15, 250, Easing.Linear);
		_ = CroatianBtn.ScaleTo(1, 250, Easing.Linear);
		EnglishLabel.FontAttributes = FontAttributes.Bold;
		CroatianLabel.FontAttributes = FontAttributes.None;
		selectedBtn = 0;
		await viewModel.LanguageSelected();
	}

	private async void CroatianBtnTapped(object sender, EventArgs e)
	{
		_ = CroatianBtn.ScaleTo(1.15, 250, Easing.Linear);
		_ = EnglishBtn.ScaleTo(1.0, 250, Easing.Linear);
		CroatianLabel.FontAttributes = FontAttributes.Bold;
		EnglishLabel.FontAttributes = FontAttributes.None;
		selectedBtn = 1;
        await viewModel.LanguageSelected();
    }
	private async void ConfirmBtnTapped(object sender, EventArgs e)
	{
		await ConfirmBtn.ScaleTo(0.9, 62, Easing.Linear);
		await ConfirmBtn.ScaleTo(0.9, 62, Easing.Linear);
		await viewModel.ConfirmAsync(selectedBtn);
	}
}