namespace SpaceXHistory.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var isChecked = e.Value;
        Application.Current.UserAppTheme = isChecked ? AppTheme.Dark : AppTheme.Light;
    }
}