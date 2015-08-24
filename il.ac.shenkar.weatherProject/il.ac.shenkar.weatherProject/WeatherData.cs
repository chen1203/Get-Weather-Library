using System;

namespace il.ac.shenkar.weatherProject
{
    /// <summary>
    /// This class describes a weather object 
    /// </summary>
    class WeatherData
    {
        private string weatherValue;
        private double temp;
        private double minTemp;
        private double maxTemp;
        private string unitTemp;
        private DateTime lastUpdate;
        private string windDesc;

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
            this.WeatherValue = weatherValue;
            this.Temp = temp;
            this.MinTemp = minTemp;
            this.MaxTemp = maxTemp;
            this.UnitTemp = unitTemp;
            this.LastUpdate = lastUpdate;
            this.WindDesc = windDesc;
        }

        /// <summary>
        /// This property refers the weather value 
        /// </summary>
        public string WeatherValue
        {
            get { return weatherValue; }
            set
            {
                if (value != null)
                {
                    weatherValue = value;
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
        public double Temp
        {
            get { return temp; }
            set { temp = value; }
        }

        /// <summary>
        /// This property refers the weather minimum temperature
        /// </summary>
        public double MinTemp
        {
            get { return minTemp; }
            set { minTemp = value; }
        }

        /// <summary>
        /// This property refers the weather maximum temperature
        /// </summary>
        public double MaxTemp
        {
            get { return maxTemp; }
            set { maxTemp = value; }
        }

        /// <summary>
        /// This property refers the unit of temperature
        /// </summary>
        public string UnitTemp
        {
            get { return unitTemp; }
            set
            {
                if (value != null)
                {
                    unitTemp = value;
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
        public DateTime LastUpdate
        {
            get { return lastUpdate; }
            set
            {
                if (lastUpdate != null)
                {
                    lastUpdate = value;
                }
                else
                {
                    throw new WeatherDataServiceException("last update is null");
                }
            }
        }

        /// <summary>
        /// This property refers the wind description
        /// </summary>
        public string WindDesc
        {
            get { return windDesc; }
            set
            {
                if (value != null)
                {
                    windDesc = value;
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
