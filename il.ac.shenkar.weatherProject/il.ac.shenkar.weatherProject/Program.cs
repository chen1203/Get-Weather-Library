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
            IWeatherDataService weatherService = factory.GetWeatherDataService(WeatherDataServiceFactory.ServiceType.OPEN_WEATHER_MAP);
            try
            {
                // create location object to get weather in
                Location location = new Location("London", "UK");
                // get the current weather
                WeatherData weatherData = weatherService.GetWeatherData(location);
                // print the weather data 
                Console.WriteLine(weatherData.ToString());
            }
            catch (WeatherDataServiceException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
