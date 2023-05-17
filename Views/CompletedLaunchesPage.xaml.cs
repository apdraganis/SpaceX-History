using SpaceXHistory.ViewModels;

namespace SpaceXHistory.Views;

public partial class CompletedLaunchesPage : ContentPage
{
    private readonly CompletedLaunchesViewModel _vm;

    public CompletedLaunchesPage()
    {
        InitializeComponent();

        _vm = new CompletedLaunchesViewModel();
        BindingContext = _vm;

        _vm.PopulateCompletedLaunches();
    }

    private async void WatchTheLaunch_Tapped(object sender, EventArgs e)
    {
        var obj = e.ToString();
        //OpenUrl(_vm.CompletedLaunches.Links.Webcast);
    }

    private async void OpenUrl(string url)
    {
        if (string.IsNullOrEmpty(url))
        {
            await DisplayAlert(string.Empty, "No video provided for this launch.", "OK");
            return;
        }

        try
        {
            Uri uri = new(url);
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            Console.Write(ex.Data);

            await DisplayAlert("Error", "Please make sure that there is a browser installed in your device.", "OK");
        }
    }
}