using System;

namespace il.ac.shenkar.weatherProject
{
    class WeatherDataServiceFactory
    {
        public enum SERVICE_TYPE { OPEN_WEATHER_MAP, OTHER };

        public IWeatherDataService getWeatherDataService(SERVICE_TYPE serviceType)
        {
            IWeatherDataService service;
            switch (serviceType)
            {
                case SERVICE_TYPE.OPEN_WEATHER_MAP:
                    Console.WriteLine("The chosen service is 'OPEN WEATHER MAP'.");
                    service = new WeatherDataService();
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

