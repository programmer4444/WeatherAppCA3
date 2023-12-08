

using Microsoft.AspNetCore.Components;
// Create a service to handle HTTP requests#
namespace WeatherApp
{
    public class WeatherApiService : ComponentBase
    {
        private readonly HttpClient _httpClient;

        public WeatherApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetWeatherForecastAsync(string cityName, int days, DateTime date)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://weatherapi-com.p.rapidapi.com/forecast.json?q={cityName}&days={days}&dt={date:yyyy-MM-dd}"),
                Headers =
            {
                { "X-RapidAPI-Key", "a382e22ad3msh2f0df04d804dc4fp123f1bjsn740c0d9b024a" },
                { "X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com" },
            },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }

}