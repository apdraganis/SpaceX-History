using SpaceXHistory.Models;
using SpaceXHistory.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXHistory.ViewModels
{
    public partial class LaunchesUpcomingViewModel
    {
        readonly LaunchService _launchService;
        public ObservableCollection<Root> UpcomingLaunches { get; set; }

        public LaunchesUpcomingViewModel()
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
