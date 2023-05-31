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
    public partial class LaunchesCompletedPageViewModel
    {
        readonly LaunchService _launchService;
        public ObservableCollection<Root> CompletedLaunches { get; set; }

        public LaunchesCompletedPageViewModel() 
        {
            CompletedLaunches = new();
            _launchService = new();
        }

        public void PopulateCompletedLaunches()
        {
            CompletedLaunches.Clear();

            ObservableCollection<Root> completedLaunches = _launchService.FetchCompletedLaunches();

            if (completedLaunches == null || completedLaunches.Count == 0) return;

            foreach (Root launch in completedLaunches)
                CompletedLaunches.Add(launch);
        }
    }
}
