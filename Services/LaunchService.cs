using Newtonsoft.Json;
using SpaceXHistory.Helpers;
using SpaceXHistory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXHistory.Services
{
    public class LaunchService
    {
        HttpClient _httpClient;

        public LaunchService()
        {
            this._httpClient = new HttpClient();
        }


        // LaunchesMainPage
        public Root GetNextLaunch()
        {
            var nextLaunchSerialized = _httpClient.GetStringAsync(Constants.BaseUrl + "launches/next").Result;
            var nextLaunchDeserialized = JsonConvert.DeserializeObject<Root>(nextLaunchSerialized);

            Root nextLaunch = nextLaunchDeserialized;

            return nextLaunch;
        }
        public Root GetLatestLaunch()
        {
            var latestLaunchSerialized = _httpClient.GetStringAsync(Constants.BaseUrl + "launches/latest").Result;
            var latestLaunchDeserialized = JsonConvert.DeserializeObject<Root>(latestLaunchSerialized);

            Root latestLaunch = latestLaunchDeserialized;

            return latestLaunch;
        }
        public Roadster GetRoadster()
        {
            var roadsterSerialized = _httpClient.GetStringAsync(Constants.BaseUrl + "roadster").Result;
            var roadsterDeserialized = JsonConvert.DeserializeObject<Roadster>(roadsterSerialized);

            Roadster roadster = roadsterDeserialized;

            return roadster;
        }


        // LaunchesUpcomingPage
        public ObservableCollection<Root> FetchUpcomingLaunches()
        {
            var upcomingLaunchesSerialized = _httpClient.GetStringAsync(Constants.BaseUrl + "launches/upcoming").Result;
            var upcomingLaunchesDeserialized = JsonConvert.DeserializeObject<List<Root>>(upcomingLaunchesSerialized);

            ObservableCollection<Root> upcomingLaunches = new(upcomingLaunchesDeserialized);

            return upcomingLaunches;
        }


        // LaunchesCompletedPage
        public ObservableCollection<Root> FetchCompletedLaunches()
        {
            var completedLaunchesSerialized = _httpClient.GetStringAsync(Constants.BaseUrl + "launches/past").Result;
            var completedLaunchesDeserialized = JsonConvert.DeserializeObject<List<Root>>(completedLaunchesSerialized);

            ObservableCollection<Root> completedLaunches = new(completedLaunchesDeserialized);

            return completedLaunches;
        }
    }
}
