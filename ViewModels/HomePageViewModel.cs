using SpaceXHistory.Models;
using SpaceXHistory.Helpers;
using Newtonsoft.Json;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SpaceXHistory.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        private readonly HttpClient _httpClient;

        [ObservableProperty]
        private Root _nextLaunch;

        [ObservableProperty]
        private Root _latestLaunch;

        [ObservableProperty]
        private Roadster _roadsterInfo;

        public HomePageViewModel()
        {
            _httpClient = new HttpClient();
        }

        public void GetNextLaunch()
        {
            var nextLaunchSerialized = _httpClient.GetStringAsync(Constants.BaseUrl + "launches/next").Result;
            NextLaunch = JsonConvert.DeserializeObject<Root>(nextLaunchSerialized);
        }

        public void GetLatestLaunch()
        {
            var latestLaunchSerialized = _httpClient.GetStringAsync(Constants.BaseUrl + "launches/latest").Result;
            LatestLaunch = JsonConvert.DeserializeObject<Root>(latestLaunchSerialized);
        }

        public void GetRoadsterInfo()
        {
            var roadsterInfoSerialized = _httpClient.GetStringAsync(Constants.BaseUrl + "roadster").Result;
            RoadsterInfo = JsonConvert.DeserializeObject<Roadster>(roadsterInfoSerialized);
        }
    }
}
