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

        // get current weather data
        public WeatherData ParseDocumentCurrent()
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

            //if the parsing doesn't succeed
            catch (Exception)
            {
                throw new WeatherDataServiceException('\n' + "Couldn't parse the xml" + '\n' + '\n'); //atalia
            }
        }

        //get future weather data
        public List<WeatherData> ParseDocumentFuture(double days)
        {
            double numOfDays = days;
                try
                {
                XDocument xmlDoc = XDocument.Load(Url);
                var weathers = from futureWeather in xmlDoc.Descendants("weatherdata")
                           select new
                           {
                                   city = futureWeather.Descendants("location").Attributes("name").First().Value,
                                   country = futureWeather.Descendants("location").Descendants("country").First().Value,
                                   fromDate = futureWeather.Descendants("forecast").Descendants("time").Attributes("from").First().Value,
                                   toDate = futureWeather.Descendants("forecast").Descendants("time").Attributes("to").First().Value,
                                   unitTemp = futureWeather.Descendants("forecast").Descendants("time").Descendants("temperature").Attributes("unit").First().Value,
                                   maxTemp = futureWeather.Descendants("forecast").Descendants("time").Descendants("temperature").Attributes("max").First().Value,
                                   minTemp = futureWeather.Descendants("forecast").Descendants("time").Descendants("temperature").Attributes("min").First().Value,
                                   temp = futureWeather.Descendants("forecast").Descendants("time").Descendants("temperature").Attributes("value").First().Value,
                                   windDesc = futureWeather.Descendants("forecast").Descendants("time").Descendants("windSpeed").Attributes("name").First().Value
                           };
                    List<WeatherData> allWeather = null;
                   List<WeatherData> allWeather = null;
                    while (numOfDays > 0)
                    {
                        numOfDays--;
                        foreach (var weather in weathers)
                        {
                            allWeather.Add(new WeatherData(weather.city, weather.country,
                                          Double.Parse(weather.temp), Double.Parse(weather.minTemp), Double.Parse(weather.maxTemp),
                                          weather.unitTemp, weather.windDesc, Convert.ToDateTime(weather.fromDate), Convert.ToDateTime(weather.toDate), numOfDays));
                        }
                    }
                    return allWeather;
                  }
            }

                //if the parsing doesn't succeed
                catch
                {
                    throw new WeatherDataServiceException('\n' + "Couldn't parse the xml" + '\n' + '\n');
                }
            }
    }
}
