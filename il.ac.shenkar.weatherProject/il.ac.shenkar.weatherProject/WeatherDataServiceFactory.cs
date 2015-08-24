using System;

namespace il.ac.shenkar.weatherProject
{
    /// <summary>
    /// Factory of weather services 
    /// </summary>
    public class WeatherDataServiceFactory 
    {
        /// <summary>
        /// Enum which contains type of services
        /// </summary>
        public enum ServiceType { OPEN_WEATHER_MAP };
        
        /// <summary>
        /// Get a specific weather service by his type
        /// </summary>
        /// <param name="serviceType"> The requested service type </param>
        /// <returns> Instanse of a class that implements the interface IWeatherDataService </returns>
        public IWeatherDataService GetWeatherDataService(ServiceType serviceType)
        {
            IWeatherDataService service;
            switch (serviceType)
            {
                case ServiceType.OPEN_WEATHER_MAP:
                    Console.WriteLine("The chosen service is 'OPEN WEATHER MAP'.\n");
                    service = WeatherDataService.Instance;
                    break;
                default:
                    Console.WriteLine("The chosen service is not exist.");
                    service = null;
                    break;
            }
            return service;
        }
    }
}

