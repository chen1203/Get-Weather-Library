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
            Console.WriteLine("*************************************************");
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

            Console.WriteLine("*************************************************");
            Console.WriteLine("\nDo you want to try get weather in your current location ?");
            Console.WriteLine("Press 'c' to continue or 'e' to exit.");
            string key = Console.ReadLine();

            while (key.Equals("c", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Enter your city name : ");
                string city = Console.ReadLine();
                Console.WriteLine("Enter your country name : ");
                string country = Console.ReadLine();
                Console.WriteLine("\n*************************************************\n");
                try
                {
                    WeatherData weatherData = weatherService.GetWeatherData(new Location(city, country));
                    Console.WriteLine(weatherData.ToString());
                }
                catch (WeatherDataServiceException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("*************************************************\n");
                Console.WriteLine("Press 'c' to continue or 'e' to exit.");
                key = Console.ReadLine();
            }
            return;
        }
    }
}
