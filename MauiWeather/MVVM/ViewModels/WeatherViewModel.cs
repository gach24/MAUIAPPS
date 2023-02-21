using MauiWeather.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiWeather.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class WeatherViewModel
    {
        #region PRIVATE MEMBERS
        public HttpClient client;
        #endregion

        #region PUBLIC PROPERTIES

        public WeatherData WeatherData { get; set; }
        public string PlaceName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public ICommand SearchCommand => new Command(async (value) =>
        {
            PlaceName = value.ToString();
            var location = await GetCoordinatesAsync(PlaceName);
            await GetWeather(location);
            IsVisible = true;
        });

        public bool IsVisible { get; set; }
        public bool IsLoading { get; set; }

        #endregion

        #region CONSTRUCTORS
        public WeatherViewModel()
        {
            client = new HttpClient();
        }
        #endregion

        #region PRIVATE METHODS
        private async Task<Location> GetCoordinatesAsync(string address)
        {
            IEnumerable<Location> locations = await Geocoding.Default.GetLocationsAsync(address);
            return locations?.FirstOrDefault();
        }

        private async Task GetWeather(Location location)
        {
            var url = $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&daily=weathercode,temperature_2m_max,temperature_2m_min&current_weather=true&timezone=America%2FChicago";
            IsLoading = true;
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = JsonSerializer.Deserialize<WeatherData>(responseStream);
                    WeatherData = data;
                    for (int i = 0; i < WeatherData.daily.time.Length; i++)
                    {
                        DailyHelper helper = new DailyHelper
                        {
                            time = WeatherData.daily.time[i],
                            weathercode = WeatherData.daily.weathercode[i],
                            temperature_2m_max = WeatherData.daily.temperature_2m_max[i],
                            temperature_2m_min = WeatherData.daily.temperature_2m_min[i]
                        };
                        WeatherData.DailyHelper.Add(helper);
                    }
                }
            }
            IsLoading = false;
        }
        #endregion
    }
}
