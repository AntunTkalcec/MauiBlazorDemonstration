using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiBlazorDemonstration.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ActivityColorValue))]
        Color activityColor;

        public bool IsNotBusy => !IsBusy;
        public Color ActivityColorValue => ActivityColor;
    }
}
