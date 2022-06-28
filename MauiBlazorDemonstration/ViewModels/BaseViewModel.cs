using CommunityToolkit.Mvvm.ComponentModel;
using MauiBlazorDemonstration.Helpers;

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

        public LanguageHelper Language
        {
            get
            {
                return LanguageHelper.Instance;
            }
        }

        
    }
}
