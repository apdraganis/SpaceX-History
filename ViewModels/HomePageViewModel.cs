using SpaceXHistory.Models;
using SpaceXHistory.Helpers;
using Newtonsoft.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using SpaceXHistory.Services;

namespace SpaceXHistory.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        LaunchService _launchService;

        [ObservableProperty]
        private Root _nextLaunch;

        [ObservableProperty]
        private Root _latestLaunch;

        [ObservableProperty]
        private Roadster _roadsterInfo;

        public HomePageViewModel()
        {
            this._launchService = new LaunchService();
        }

        public async Task GetNextLaunch()
        {
            NextLaunch = await _launchService.GetNextLaunch();
        }

        public async Task GetLatestLaunch()
        {
            LatestLaunch = await _launchService.GetLatestLaunch();
        }

        public async Task GetRoadsterInfo()
        {
            RoadsterInfo = await _launchService.GetRoadster();
        }
    }
}
