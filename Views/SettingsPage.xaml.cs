namespace SpaceXHistory.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
		var isToggled = e.Value;
		Application.Current.UserAppTheme = isToggled ? AppTheme.Dark : AppTheme.Light;
    }
}