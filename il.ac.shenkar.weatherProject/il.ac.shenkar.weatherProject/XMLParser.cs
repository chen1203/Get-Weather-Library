using System;
using System.Linq;
using System.Xml.Linq;

namespace il.ac.shenkar.weatherProject
{
    class XMLParser : IParser
    {
        private string Url { get; set; }

        public XMLParser(string url)
        {
            Url = url;
        }

        public WeatherData ParseDocument()
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(Url);
                var weatherQuery = from currentWeather in xmlDoc.Descendants("current")
                                   select new
                                   {
                                       city = currentWeather.Descendants("city").Attributes("name").First().Value,
                                       country = currentWeather.Descendants("city").Descendants("country").First().Value,
                                       weatherValue = currentWeather.Descendants("weather").Attributes("value").First().Value,
                                       temp = currentWeather.Descendants("temperature").Attributes("value").First().Value,
                                       minTemp = currentWeather.Descendants("temperature").Attributes("min").First().Value,
                                       maxTemp = currentWeather.Descendants("temperature").Attributes("max").First().Value,
                                       unitTemp = currentWeather.Descendants("temperature").Attributes("unit").First().Value,
                                       lastUpdate = currentWeather.Descendants("lastupdate").Attributes("value").First().Value,
                                       windDesc = currentWeather.Descendants("wind").Descendants("speed").Attributes("name").First().Value
                                   };

                var weather = weatherQuery.ElementAt(0);
                return new WeatherData(weather.city, weather.country, weather.weatherValue,
                                    Double.Parse(weather.temp), Double.Parse(weather.minTemp), Double.Parse(weather.maxTemp),
                                    weather.unitTemp, Convert.ToDateTime(weather.lastUpdate), weather.windDesc);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
