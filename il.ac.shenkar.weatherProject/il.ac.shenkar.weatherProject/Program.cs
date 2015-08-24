using System;

namespace il.ac.shenkar.weatherProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the factory
            WeatherDataServiceFactory factory = new WeatherDataServiceFactory();
            // get the desired service from factory
            IWeatherDataService weatherService = factory.getWeatherDataService(WeatherDataServiceFactory.SERVICE_TYPE.OPEN_WEATHER_MAP);
            // use the weather service
            Location location = new Location("London", "uk");
            // if we want a current weather
            WeatherData weatherData = weatherService.GetWeatherData(location);
            // if we want future weather
            List<WeatherData> wd = weatherService.GetFutureWeatherData(location, 5);
            // print the data 
            Console.WriteLine(weatherData.ToString());
        }
    }
}
