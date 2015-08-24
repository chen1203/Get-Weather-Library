
namespace il.ac.shenkar.weatherProject
{
    interface IWeatherDataService
    {
        WeatherData GetWeatherData(Location location);
        List<WeatherData> GetFutureWeatherData(Location location, double numOfDays);
    }
}
