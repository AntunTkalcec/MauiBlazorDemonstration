using MauiBlazorDemonstration.ViewModels;

namespace MauiBlazorDemonstration.Views;

public partial class DogsDisplayNativePage : ContentPage
{
	public DogsDisplayNativePage(DogsNativeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}