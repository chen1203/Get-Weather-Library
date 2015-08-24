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

        // going to the url for current weather
        public WeatherData GetWeatherData(Location location)
        {
            try
            {
                // create the url string
                string url = "http://api.openweathermap.org/data/2.5/weather?q=" + location.Name + "," + location.Country + "&mode=xml";
                // send the url to parser and get from it the weather data object
                IParser parser = new XMLParser(url);
                return parser.ParseDocumentCurrent();
            }
            catch (Exception)
            {
                //if there is no connection to the internet
                throw new WeatherDataServiceException('\n' + "No Internet Connection, Failed to load and parse weather data from web service" + '\n' + '\n'); 
            }
        }

        // going to the url for future weather
        public List<WeatherData> GetFutureWeatherData(Location location, double numOfDays)
        {
            double days = numOfDays;
                try
                {
                    // create the url string
                    string url = "http://api.openweathermap.org/data/2.5/forecast?q=" + location.Name + "," + location.Country + "&mode=xml";
                    // send the url to parser and get from it the weather data object
                    IParser parser = new XMLParser(url);
                    return parser.ParseDocumentFuture(days);
                }
                catch (Exception)
                {
                    //if there is no connection to the internet
                    throw new WeatherDataServiceException('\n' + "No Internet Connection, Failed to load and parse weather data from web service" + '\n' + '\n'); 
                }
            }
    }
}
