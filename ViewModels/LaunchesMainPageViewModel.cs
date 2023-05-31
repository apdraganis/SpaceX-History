using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceXHistory.Models;
using SpaceXHistory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXHistory.ViewModels
{
    public partial class LaunchesMainPageViewModel : BaseViewModel
    {
        readonly LaunchService launchService;

        [ObservableProperty]
        private Root _nextLaunch;

        [ObservableProperty]
        private Root _latestLaunch;

        [ObservableProperty]
        private Roadster _roadsterInfo;

        public LaunchesMainPageViewModel()
        {
            this.launchService = new();
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
