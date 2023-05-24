using Newtonsoft.Json;
using SpaceXHistory.Helpers;
using SpaceXHistory.Models;
using System;
using System.Collections.Generic;
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
            _httpClient = new HttpClient();
        }

        Root _nextLaunch = new ();
        Root _latestLaunch = new ();
        Roadster _roadster = new ();

        public async Task<Root> GetNextLaunch()
        {
            var res = await _httpClient.GetAsync(Constants.BaseUrl + "launches/next");

            if (res.IsSuccessStatusCode)
            {
                _nextLaunch = await res.Content.ReadFromJsonAsync<Root>();
            }

            return _nextLaunch;
        }

        public async Task<Root> GetLatestLaunch()
        {
            var res = await _httpClient.GetAsync(Constants.BaseUrl + "launches/latest");

            if (res.IsSuccessStatusCode)
            {
                _latestLaunch = await res.Content.ReadFromJsonAsync<Root>();
            }

            return _latestLaunch;
        }

        public async Task<Roadster> GetRoadster()
        {
            var res = await _httpClient.GetAsync(Constants.BaseUrl + "launches/roadster");

            if (res.IsSuccessStatusCode)
            {
                _latestLaunch = await res.Content.ReadFromJsonAsync<Root>();
            }

            return _roadster;
        }
    }
}
