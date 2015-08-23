using System;

namespace il.ac.shenkar.weatherProject
{
    class WeatherDataService : IWeatherDataService
    {
        private static WeatherDataService instance;

        public WeatherDataService() { }

        // singleton design pattern
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

        // get weather data due to location only (city and country)
        public WeatherData GetWeatherData(Location location)
        {
            try
            {
                // create the url string
                string url = "http://api.openweathermap.org/data/2.5/weather?q=" + location.Name + "," + location.Country + "&mode=xml";
                // send the url to parser and get from it the weather data object
                IParser parser = new XMLParser(url);
                return parser.ParseDocument();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
