using SpaceXHistory.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using SpaceXHistory.Services;
using CommunityToolkit.Mvvm.Input;

namespace SpaceXHistory.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        readonly LaunchService launchService;

        [ObservableProperty]
        private Root _nextLaunch;

        [ObservableProperty]
        private Root _latestLaunch;

        [ObservableProperty]
        private Roadster _roadsterInfo;

        public HomePageViewModel()
        {
            this.launchService = new ();
        }

        [RelayCommand]
        public void GetNextLaunch()
        {
            NextLaunch = launchService.GetNextLaunch();
        }

        [RelayCommand]
        public void GetLatestLaunch()
        {
            LatestLaunch = launchService.GetLatestLaunch();
        }

        [RelayCommand]
        public void GetRoadsterInfo()
        {
            RoadsterInfo = launchService.GetRoadster();
        }
    }
}
