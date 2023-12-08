using BlazorStrap;

namespace WeatherApp
{
    public class Services
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Other service registrations
            services.AddBlazorStrap();
            services.AddScoped<WeatherApiService>();
        }
    }
}
