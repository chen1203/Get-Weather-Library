namespace il.ac.shenkar.weatherProject
{
    /// <summary>
    /// This interface defines the ParseDocument method 
    /// and it's purpose is to get the data from a url address and parse it to weatherData object
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parses the document from the url address
        /// </summary>
        /// <returns> The weatherData object after parsing </returns>
        WeatherData ParseDocument();
    }
}
