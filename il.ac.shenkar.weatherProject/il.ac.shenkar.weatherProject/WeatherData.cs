using System;

namespace il.ac.shenkar.weatherProject
{
    /// <summary>
    /// This class describes a weather object 
    /// </summary>
    public class WeatherData
    {
        private string _weatherValue;
        private string _unitTemp;
        private string _windDesc;

        /// <summary>
        /// Weather data constructor
        /// </summary>
        /// <param name="weatherValue"></param>
        /// <param name="temp"></param>
        /// <param name="minTemp"></param>
        /// <param name="maxTemp"></param>
        /// <param name="unitTemp"></param>
        /// <param name="lastUpdate"></param>
        /// <param name="windDesc"></param>
        public WeatherData(string weatherValue, double temp, double minTemp, double maxTemp,
                           string unitTemp, DateTime lastUpdate, string windDesc)
        {
            WeatherValue = weatherValue;
            Temp = temp;
            MinTemp = minTemp;
            MaxTemp = maxTemp;
            UnitTemp = unitTemp;
            LastUpdate = lastUpdate;
            WindDesc = windDesc;
        }

        /// <summary>
        /// This property refers the weather value 
        /// </summary>
        public string WeatherValue
        {
            get { return _weatherValue; }
            set
            {
                if (value != null)
                {
                    _weatherValue = value;
                }
                else
                {
                    throw new WeatherDataServiceException("weather value is null");
                }
            }
        }

        /// <summary>
        /// This property refers the weather temperature
        /// </summary>
        public double Temp { get; set; }

        /// <summary>
        /// This property refers the weather minimum temperature
        /// </summary>
        public double MinTemp { get; set; }

        /// <summary>
        /// This property refers the weather maximum temperature
        /// </summary>
        public double MaxTemp { get; set; }

        /// <summary>
        /// This property refers the unit of temperature
        /// </summary>
        public string UnitTemp
        {
            get { return _unitTemp; }
            set
            {
                if (value != null)
                {
                    _unitTemp = value;
                }
                else
                {
                    throw new WeatherDataServiceException("unit of temperature is null");
                }
            }
        }

        /// <summary>
        /// This property refers the weather last update
        /// </summary>
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// This property refers the wind description
        /// </summary>
        public string WindDesc
        {
            get { return _windDesc; }
            set
            {
                if (value != null)
                {
                    _windDesc = value;
                }
                else
                {
                    throw new WeatherDataServiceException("wind description is null");
                }
            }
        }

        /// <summary>
        /// Override the ToString method 
        /// </summary>
        /// <returns> String describing the weather data </returns>
        override public string ToString()
        {
            return "\n*** Weather Data ***" +
                "\nWeather value : " + WeatherValue +
                "\nTemperature : " + Temp +
                "\nMinimum temperature : " + MinTemp +
                "\nMaximun temperature : " + MaxTemp +
                "\nUnitTemp : " + UnitTemp +
                "\nLast update : " + LastUpdate +
                "\nWind description: " + WindDesc + "\n";
        }
    }
}
