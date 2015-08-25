using System;

namespace il.ac.shenkar.weatherProject
{
    /// <summary>
    /// General exception for the weather data service
    /// </summary>
    public class WeatherDataServiceException : ApplicationException
    {
        /// <summary>
        /// weather data service exception constructor
        /// </summary>
        /// <param name="str"> The string describes the exception </param>
        public WeatherDataServiceException(string str) : base(str)
        {
        }
    }
}
