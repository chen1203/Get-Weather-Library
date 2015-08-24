namespace il.ac.shenkar.weatherProject
{
    /// <summary>    
    /// This interface defines the GetWeatherData method 
    /// and it's purpose is to get the weather data
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
