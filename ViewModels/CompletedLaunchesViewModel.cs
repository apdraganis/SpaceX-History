using Newtonsoft.Json;
using SpaceXHistory.Helpers;
using SpaceXHistory.Models;
using SpaceXHistory.Services;
using System.Collections.ObjectModel;


namespace SpaceXHistory.ViewModels
{
    public class CompletedLaunchesViewModel : BaseViewModel
    {
        readonly LaunchService _launchService;
        public ObservableCollection<Root> CompletedLaunches { get; set; }

        public CompletedLaunchesViewModel()
        {
            CompletedLaunches = new ();
            _launchService = new ();
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
