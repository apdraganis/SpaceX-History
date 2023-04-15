using Newtonsoft.Json.Bson;
using SpaceXHistory.ViewModels;

namespace SpaceXHistory.Views;

public partial class HomePage : ContentPage
{
	private readonly HomePageViewModel _viewModel;

	public HomePage()
	{
		InitializeComponent();

		_viewModel = new HomePageViewModel();
		BindingContext = _viewModel;

		_viewModel.GetNextLaunch();
		_viewModel.GetLatestLaunch();
		_viewModel.GetRoadsterInfo();
	}

	private void NextLaunchWebcastTap(object sender, EventArgs e)
	{
		OpenUrl(_viewModel.NextLaunch.Links.Webcast);
	}

    private void LatestLaunchWebcastTap(object sender, EventArgs e)
    {
        OpenUrl(_viewModel.LatestLaunch.Links.Webcast);
    }

	private void RoadsterWebcastTap(Object sender, EventArgs e)
	{
		OpenUrl(_viewModel.RoadsterInfo.Video);
	}

    private void RoadsterWikiTap(Object sender, EventArgs e)
    {
        OpenUrl(_viewModel.RoadsterInfo.Wikipedia);
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