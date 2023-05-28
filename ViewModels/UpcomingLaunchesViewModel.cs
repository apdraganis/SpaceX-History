using Newtonsoft.Json;
using SpaceXHistory.Helpers;
using SpaceXHistory.Models;
using SpaceXHistory.Services;
using System.Collections.ObjectModel;

namespace SpaceXHistory.ViewModels
{
    public partial class UpcomingLaunchesViewModel : BaseViewModel
    {
        readonly LaunchService _launchService;
        public ObservableCollection<Root> UpcomingLaunches { get; set; }

        public UpcomingLaunchesViewModel()
        {
            UpcomingLaunches = new();
            this._launchService = new();
        }

        public void PopulateUpcomingLaunches()
        {
            UpcomingLaunches.Clear();
            ObservableCollection<Root> upcomingLaunches = _launchService.FetchUpcomingLaunches();

            if (upcomingLaunches == null || upcomingLaunches.Count == 0) return;

            foreach (Root launch in upcomingLaunches)
                UpcomingLaunches.Add(launch);
        }

        
    }
}
