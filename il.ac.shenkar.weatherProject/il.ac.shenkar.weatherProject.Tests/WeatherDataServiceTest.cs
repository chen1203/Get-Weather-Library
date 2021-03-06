using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using il.ac.shenkar.weatherProject;

namespace il.ac.shenkar.weatherProject.Tests
{
    [TestClass]
    public partial class WeatherDataServiceTest
    {
        /// <summary>
        /// Testing GetWeatherData(Location) method in London,UK
        /// Expected same data so the assert will be true
        /// </summary>
        [TestMethod()]
        public void GetWeatherDataValueTest()
        {
            // get the weather data in London using the GetWeatherData function
            WeatherDataServiceFactory factory = new WeatherDataServiceFactory();
            IWeatherDataService weatherService = factory.GetWeatherDataService(WeatherDataServiceFactory.ServiceType.OpenWeatherMap);
            Location locationTest = new Location("London", "UK");
            WeatherData weatherDataToTest = weatherService.GetWeatherData(locationTest);
            // get the weather data in London from the website
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + locationTest.City + "," + locationTest.Country + "&mode=xml";
            WeatherData weatherSrc = GetWeatherByUrlForTesting(url);
            Assert.IsTrue(weatherSrc.Equals(weatherDataToTest));
        }

        /// <summary>
        /// Testing GetWeatherData(Location) method with empty value in country
        /// Expected exception so we assert fail 
        /// </summary>
        [TestMethod()]
        public void GetWeatherDataEmptyValueTest()
        {
            WeatherDataServiceFactory factory = new WeatherDataServiceFactory();
            IWeatherDataService weatherService = factory.GetWeatherDataService(WeatherDataServiceFactory.ServiceType.OpenWeatherMap);
            try
            {
                WeatherData weatherDataToTest = weatherService.GetWeatherData(new Location("London", ""));
                Assert.Fail("Expected exception");
            }
            catch (WeatherDataServiceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Testing GetWeatherData(Location) method with null value in city and country
        /// Expected exception so we assert fail 
        /// </summary>
        [TestMethod()]
        public void GetWeatherDataNullValueTest()
        {
            WeatherDataServiceFactory factory = new WeatherDataServiceFactory();
            IWeatherDataService weatherService = factory.GetWeatherDataService(WeatherDataServiceFactory.ServiceType.OpenWeatherMap);
            try
            {
                WeatherData weatherDataToTest = weatherService.GetWeatherData(new Location(null, null));
                Assert.Fail("Expected exception");
            }
            catch (WeatherDataServiceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Testing GetWeatherData(Location) method with null value in location
        /// Expected exception so we assert fail 
        /// </summary>
        [TestMethod()]
        public void GetWeatherDataNullLocationTest()
        {
            WeatherDataServiceFactory factory = new WeatherDataServiceFactory();
            IWeatherDataService weatherService = factory.GetWeatherDataService(WeatherDataServiceFactory.ServiceType.OpenWeatherMap);
            try
            {
                WeatherData weatherDataToTest = weatherService.GetWeatherData(null);
                Assert.Fail("Expected exception");
            }
            catch (WeatherDataServiceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Testing GetWeatherData(Location) method with not exist city X or country Y
        /// Expected exception so we assert fail 
        /// </summary>
        [TestMethod()]
        public void GetWeatherDataNotExistTest()
        {
            WeatherDataServiceFactory factory = new WeatherDataServiceFactory();
            IWeatherDataService weatherService = factory.GetWeatherDataService(WeatherDataServiceFactory.ServiceType.OpenWeatherMap);
            try
            {
                WeatherData weatherDataToTest = weatherService.GetWeatherData(new Location(";", ";"));
                Assert.Fail("Expected exception");
            }
            catch (WeatherDataServiceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Parse xml file from a given url
        /// and create weatherData object from all the details
        /// </summary>
        /// <param name="url"></param>
        /// <returns> WeatherData object with all the details from the url </returns>
        private WeatherData GetWeatherByUrlForTesting(string url)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(url);
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
            catch (WeatherDataServiceException e)
            {
                Console.WriteLine(e.Source);
                throw new WeatherDataServiceException("Couldn't parse the xml");
            }
        }
    }
}
