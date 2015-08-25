using System;

namespace il.ac.shenkar.weatherProject
{
    /// <summary>
    /// This service returns the current weather 
    /// </summary>
    public class WeatherDataService : IWeatherDataService
    {
        /// <summary>
        /// Instance of the service as a part of the singleton implementation
        /// </summary>
        private static WeatherDataService _instance;

        /// <summary>
        /// Singleton design pattern implementation
        /// </summary>
        public static WeatherDataService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WeatherDataService();
                }
                return _instance;
            }
        }

        public static WeatherDataService Instance1
        {
            get
            {
                return _instance;
            }

            set
            {
                _instance = value;
            }
        }

        public static WeatherDataService Instance2
        {
            get
            {
                return _instance;
            }

            set
            {
                _instance = value;
            }
        }

        /// <summary>
        /// Get the weather data due to location 
        /// </summary>
        /// <param Location(city name, country name)></param>
        /// <exception cref="WeatherDataServiceException"></exception>
        /// <returns> The weather data object </returns>
        public WeatherData GetWeatherData(Location location)
        {
            Console.WriteLine("The service got a request to return the current weather in this location - \n" + 
                            "City : " + location.City + "\nCountry : " + location.Country);
            
            try
            {
                // create the url string
                string url = "http://api.openweathermap.org/data/2.5/weather?q=" + location.City + "," + location.Country + "&mode=xml";
                // send the url to parser and get from it the weather data object
                IParser parser = new XMLParser(url);
                return parser.ParseDocument();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Source);
                throw new WeatherDataServiceException("url not found, change location :\n" + location.ToString());
            }
        }
    }
}
