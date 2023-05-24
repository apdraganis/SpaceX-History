using Newtonsoft.Json;
using SpaceXHistory.Helpers;
using SpaceXHistory.Models;
using System.Collections.ObjectModel;

namespace SpaceXHistory.ViewModels
{
    public class UpcomingLaunchesViewModel : BaseViewModel
    {
        public ObservableCollection<Root> UpcomingLaunches { get; set; }

        private readonly HttpClient _httpClient;

        public UpcomingLaunchesViewModel()
        {
            _httpClient = new HttpClient();
            UpcomingLaunches = new ObservableCollection<Root>();
        }

        public void PopulateUpcomingLaunches()
        {
            UpcomingLaunches.Clear();

            foreach (Root launch in FetchUpcomingLaunches())
                UpcomingLaunches.Add(launch);
        }

        private ObservableCollection<Root> FetchUpcomingLaunches()
        {
            var upcomingLaunchSerialized = _httpClient.GetStringAsync(Constants.BaseUrl + "launches/upcoming").Result;
            var upcomingLaunchDeserialized = JsonConvert.DeserializeObject<List<Root>>(upcomingLaunchSerialized);

            ObservableCollection<Root> allLaunches = new(upcomingLaunchDeserialized);

            return allLaunches;
        }
    }
}
