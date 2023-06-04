
namespace SpaceXHistory;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        if (Connectivity.Current.NetworkAccess == NetworkAccess.None)
        {
            await DisplayAlert("Error", "Internet access has been lost, please try again.", "OK");
            return;
        }

        try
        {
            Uri uri = new("https://github.com/apdraganis/SpaceX-History");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            Console.Write(ex.Data);

            await DisplayAlert("Error", "Please make sure that there is a browser installed in your device.", "OK");
        }
    }
}
