using SpaceXHistory.ViewModels;

namespace SpaceXHistory.Views;

public partial class UpcomingLaunchesPage : ContentPage
{
	private readonly UpcomingLaunchesViewModel _viewModel;

	public UpcomingLaunchesPage()
	{
		InitializeComponent();

		_viewModel = new UpcomingLaunchesViewModel();
		BindingContext = _viewModel;

		_viewModel.PopulateNextLaunch();
	}
}