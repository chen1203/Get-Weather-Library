using System;
using System.Linq;
using System.Xml.Linq;

namespace il.ac.shenkar.weatherProject
{
    /// <summary>
    /// This class purpose is to retrive the data from the xml site and 
    /// parse tha data to weather object that holds all the weather details
    /// </summary>
    class XMLParser : IParser
    {
        private string url;

        /// <summary>
        /// XML parser constructor
        /// </summary>
        /// <param name="url"></param>
        public XMLParser(string url)
        {
            Url = url;
        }

        /// <summary>
        /// This property refers to the parser's url
        /// </summary>
        public string Url
        {
            get { return url; }
            set
            {
                if (value != null)
                {
                    url = value;
                }
                else
                {
                    throw new WeatherDataServiceException("url is null");
                }
            }
        }

        /// <summary>
        /// Parses the xml file to weather object
        /// </summary>
        /// <returns> The weather data object after parsing </returns>
        public WeatherData ParseDocument()
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(Url);
                var weatherQuery = from currentWeather in xmlDoc.Descendants("current")
                                   select new
                                   {
                                       weatherValue = currentWeather.Descendants("weather").Attributes("value").First().Value,
                                       temp = currentWeather.Descendants("temperature").Attributes("value").First().Value,
                                       minTemp = currentWeather.Descendants("temperature").Attributes("min").First().Value,
                                       maxTemp = currentWeather.Descendants("temperature").Attributes("max").First().Value,
                                       unitTemp = currentWeather.Descendants("temperature").Attributes("unit").First().Value,
                                       lastUpdate = currentWeather.Descendants("lastupdate").Attributes("value").First().Value,
                                       windDesc = currentWeather.Descendants("wind").Descendants("speed").Attributes("name").First().Value
                                   };

                var weather = weatherQuery.ElementAt(0);
                return new WeatherData(weather.weatherValue, Double.Parse(weather.temp), Double.Parse(weather.minTemp), Double.Parse(weather.maxTemp),
                                    weather.unitTemp, Convert.ToDateTime(weather.lastUpdate), weather.windDesc);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Source);
                throw new WeatherDataServiceException("Couldn't parse the xml");
            }
        }
    }
}
