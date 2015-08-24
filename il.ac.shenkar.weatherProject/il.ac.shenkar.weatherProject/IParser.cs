namespace il.ac.shenkar.weatherProject
{
    /// <summary>
    /// This interface defines the ParseDocument method 
    /// and its purpose is to get the data from a weather site and return the parsed object
    /// </summary>
    interface IParser
    {
        /// <summary>
        /// Parses the xml document from the url
        /// </summary>
        /// <returns> The weather data object after parsing </returns>
        WeatherData ParseDocument();
    }
}
