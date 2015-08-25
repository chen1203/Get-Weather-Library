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
                if (!string.IsNullOrEmpty(value))
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
                if (!string.IsNullOrEmpty(value))
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
                if (!string.IsNullOrEmpty(value))
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

        /// <summary>
        /// Override the Equals method 
        /// </summary>
        /// <param name="obj"> weatherData object to comparison </param>
        /// <returns> true if the given object is equals to this instance </returns>
        override public bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }
            // If parameter cannot be cast to WeatherData return false.
            WeatherData wd = obj as WeatherData;
            if ((System.Object)wd == null)
            {
                return false;
            }
            // Return true if the fields match:
            return AllFieldsEquals(this, wd);
        }

        /// <summary>
        /// Comparison between all fields in two weatherData objects
        /// </summary>
        /// <param name="wd1"> weatherData first object </param>
        /// <param name="wd2"> weatherData second object </param>
        /// <returns> true if all fields are equal and false otherwise </returns>
        private bool AllFieldsEquals(WeatherData wd1, WeatherData wd2)
        {
            if (wd1.WeatherValue.Equals(wd2.WeatherValue) &&
                wd1.Temp == wd2.Temp &&
                wd1.MinTemp == wd2.MinTemp &&
                wd1.MaxTemp == wd2.MaxTemp &&
                wd1.UnitTemp.Equals(wd2.UnitTemp) &&
                wd1.LastUpdate.Equals(wd2.LastUpdate) &&
                wd1.WindDesc.Equals(wd2.WindDesc))
                return true;
            else
                return false;
        }
    }
}
