using SpaceXHistory.Models;
using SpaceXHistory.ViewModels;

namespace SpaceXHistory.Views;

public partial class UpcomingLaunchesPage : ContentPage
{
	private readonly UpcomingLaunchesViewModel _vm;

	public UpcomingLaunchesPage()
	{
        
		InitializeComponent();

        _vm = new();
		BindingContext = _vm;

		_vm.PopulateUpcomingLaunches();
	}
    
    private void WatchTheLaunch_Tapped(object sender, EventArgs e)
    {
        Root bc = ((VisualElement)sender).BindingContext as Root;

        if (bc != null)
            OpenUrl(bc.Links.Webcast);
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