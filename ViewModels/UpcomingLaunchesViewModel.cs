using Newtonsoft.Json;
using SpaceXHistory.Helpers;
using SpaceXHistory.Models;
using System.Collections.ObjectModel;

namespace SpaceXHistory.ViewModels
{
    public class UpcomingLaunchesViewModel : BaseViewModel
    {
        public ObservableCollection<Root> NextLaunches {  get; set; }

        private readonly HttpClient _httpClient;

        public UpcomingLaunchesViewModel()
        {
            _httpClient = new HttpClient();
            NextLaunches = new ObservableCollection<Root>();
        }

        public void PopulateNextLaunches()
        {
            foreach (Root launch in FetchNextLaunches())
            {
                NextLaunches.Add(launch);
            }
        }

        private ObservableCollection<Root> FetchNextLaunches()
        {
            var nextLaunchSerialized = _httpClient.GetStringAsync(Constants.BaseUrl + "launches/upcoming").Result;
            var nextLaunchDeserialized = JsonConvert.DeserializeObject<List<Root>>(nextLaunchSerialized);

            ObservableCollection<Root> allLaunches = new(nextLaunchDeserialized);

            return allLaunches;
        }
    }
}
