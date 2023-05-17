using Newtonsoft.Json;
using SpaceXHistory.Helpers;
using SpaceXHistory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXHistory.ViewModels
{
    public class CompletedLaunchesViewModel : BaseViewModel
    {
        public ObservableCollection<Root> CompletedLaunches { get; set; }
        private readonly HttpClient _httpClient;

        public CompletedLaunchesViewModel()
        {
            _httpClient = new HttpClient();
            CompletedLaunches = new ObservableCollection<Root>();
        }

        public void PopulateCompletedLaunches()
        {
            foreach (Root launch in FetchCompletedLaunches())
                CompletedLaunches.Add(launch);
        }

        private ObservableCollection<Root> FetchCompletedLaunches()
        {
            var completedLaunchesSerialized = _httpClient.GetStringAsync(Constants.BaseUrl + "launches/past").Result;
            var completedLaunchesDeserialized = JsonConvert.DeserializeObject<List<Root>>(completedLaunchesSerialized);

            ObservableCollection<Root> allLaunches = new(completedLaunchesDeserialized);

            return allLaunches;
        }
    }
}
