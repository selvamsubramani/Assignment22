namespace FSE.Assignment22.Service.Core
{
    public class WeatherService : IWeatherService
    {
        public double CelciusToFarenheit(double temp)
        {
            return (temp * 9 / 5) + 32;//(34°C × 9/5) + 32 = 93.2°F
        }
        public double FarenheitToCelcius(double temp)
        {
            return (temp - 32) * 5 / 9;//(100°F − 32) × 5/9 = 37.778°C
        }
    }
}