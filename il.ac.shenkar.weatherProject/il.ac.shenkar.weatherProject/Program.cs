using System;

namespace il.ac.shenkar.weatherProject
{
    /// <summary>
    /// The program purpose is to use and check the weather data service
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // create the factory of services
            WeatherDataServiceFactory factory = new WeatherDataServiceFactory();
            // get one service from the factory by requested type
            IWeatherDataService weatherService = factory.getWeatherDataService(WeatherDataServiceFactory.SERVICE_TYPE.OPEN_WEATHER_MAP);
            // use the weather service
            Location location = new Location("london", "UK");
            // get the current weather
            WeatherData weatherData = weatherService.GetWeatherData(location);
            // print the weather data 
            Console.WriteLine(weatherData.ToString());
        }
    }
}
