using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
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
    public class UpcomingLaunchesViewModel : BaseViewModel
    {
        public ObservableCollection<Root> NextLaunch {  get; set; }

        private readonly HttpClient _httpClient;

        public UpcomingLaunchesViewModel()
        {
            _httpClient = new HttpClient();
            NextLaunch = new ObservableCollection<Root>();
        }

        public void PopulateNextLaunch()
        {
            foreach (Root launch in FetchAllNextLaunches())
            {
                NextLaunch.Add(launch);
            }
        }

        private ObservableCollection<Root> FetchAllNextLaunches()
        {
            var nextLaunchSerialized = _httpClient.GetStringAsync(Constants.BaseUrl + "launches/upcoming").Result;
            var nextLaunchDeserialized = JsonConvert.DeserializeObject<List<Root>>(nextLaunchSerialized);

            ObservableCollection<Root> allLaunches = new(nextLaunchDeserialized);

            return allLaunches;
        }
    }
}
