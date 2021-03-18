using Adventura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adventura.UI
{
    public class UIService
    {
        private HttpClient _client;

        public UIService()
        {
            _client = new HttpClient();
        }

        public async Task<Adventure> GetAdventureAsync(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"https://localhost:44301/api/adventure/{id}/");

            if (response.IsSuccessStatusCode)
            {
                //Adventure adventure = await response.Content.ReadAsAsync<Adventure>();
                //return adventure;
            }

            return new Adventure() { AdventureId = default };
        }

        public async Task<Location> GetLocationAsync(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"https://localhost:44301/api/Location/{id}/");
            if (response.IsSuccessStatusCode)
            {
                //Location location = await response.Content.ReadAsAsync<Location>();
                //return location;
            }

            return new Location() { LocationName = default };
        }
        
        public async Task<Activity> GetActivityAsync(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"https://localhost:44301/api/Activity/{id}/");
            if (response.IsSuccessStatusCode)
            {
                //Activity activity = await response.Content.ReadAsAsync<Activity>();
                //return activity;
            }

            return new Activity() { ActivityType = default };
        }


        public async Task<T> GetAsync<T>(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                //return await response.Content.ReadAsAsync<T>();
            }
            return default;
        }


    }
}
