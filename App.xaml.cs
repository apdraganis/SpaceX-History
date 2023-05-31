namespace SpaceXHistory;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell(); //Views.BaseTabbedPage();
	}
}
