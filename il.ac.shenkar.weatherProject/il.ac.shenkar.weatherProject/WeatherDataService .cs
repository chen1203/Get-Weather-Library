using System;

namespace il.ac.shenkar.weatherProject
{
    /// <summary>
    /// This service returns the current weather 
    /// </summary>
    class WeatherDataService : IWeatherDataService
    {
        /// <summary>
        /// Instance of the service as a part of the singletone implementation
        /// </summary>
        private static WeatherDataService instance;

        /// <summary>
        /// Singletone design patern implementation
        /// </summary>
        public static WeatherDataService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WeatherDataService();
                }
                return instance;
            }
        }

        /// <summary>
        /// Get the weather data due to location 
        /// </summary>
        /// <param name="location"></param>
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
                throw new WeatherDataServiceException("Couldn't finish parsing successfully of location :\n" + location.ToString());
            }
        }
    }
}
