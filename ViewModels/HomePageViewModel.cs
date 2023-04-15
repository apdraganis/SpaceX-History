using SpaceXHistory.Models;
using SpaceXHistory.Helpers;
using Newtonsoft.Json;

namespace SpaceXHistory.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public Root NextLaunch
        {
            get => _nextLaunch;
            set => SetProperty(ref _nextLaunch, value);
        }

        public Root LatestLaunch
        {
            get => _latestLaunch;
            set => SetProperty(ref _latestLaunch, value);
        }

        public Roadster RoadsterInfo
        {
            get => _roadsterInfo;
            set => SetProperty(ref _roadsterInfo, value);
        }

        private readonly HttpClient _httpClient;
        private Root _nextLaunch;
        private Root _latestLaunch;
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
