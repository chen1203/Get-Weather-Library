using System;

namespace il.ac.shenkar.weatherProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the factory
            WeatherDataServiceFactory factory = new WeatherDataServiceFactory();
            // get thd desired service from factory
            IWeatherDataService weatherService = factory.getWeatherDataService(WeatherDataServiceFactory.SERVICE_TYPE.OPEN_WEATHER_MAP);
            // use the weather service
            Location location = new Location("London", "uk");
            WeatherData weatherData = weatherService.GetWeatherData(location);
            Console.WriteLine(weatherData.ToString());
        }
    }
}
