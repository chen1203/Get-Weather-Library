
namespace il.ac.shenkar.weatherProject
{
    /// <summary>
    /// This interface defines a service which returns the current weather 
    /// </summary>
    interface IWeatherDataService
    {
        /// <summary>
        /// Get the current weather details in the requested location
        /// </summary>
        /// <param name="location"> Represents the requested location to find the weather in </param>
        /// <returns> The weather data object which represents the current weather by location </returns>
        WeatherData GetWeatherData(Location location);
    }
}
