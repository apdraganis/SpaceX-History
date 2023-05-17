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
    public class LatestLaunchesViewModel : BaseViewModel
    {
        public ObservableCollection<Root> LatestLaunches { get; set; }
        private readonly HttpClient _httpClient;

        public LatestLaunchesViewModel()
        {
            _httpClient = new HttpClient();
            LatestLaunches = new ObservableCollection<Root>();
        }

        public void PopulateLatestLaunches()
        {
            foreach (Root launch in FetchLatestLaunches())
                LatestLaunches.Add(launch);
        }

        private ObservableCollection<Root> FetchLatestLaunches()
        {
            var latestLaunchesSerialized = _httpClient.GetStringAsync(Constants.BaseUrl + "launches/past").Result;
            var latestLaunchesDeserialized = JsonConvert.DeserializeObject<List<Root>>(latestLaunchesSerialized);

            ObservableCollection<Root> allLaunches = new(latestLaunchesDeserialized);

            return allLaunches;
        };
    }
}
