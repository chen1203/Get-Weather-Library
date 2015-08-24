
namespace il.ac.shenkar.weatherProject
{
        /// <summary>
    /// This interface defines the ParseDocument method 
    /// and it's purpose is to get the data from an xml site
    /// two different parsers - for current weather and for future weather
    /// </summary>
    interface IParser
    {
        /// <summary>
        /// Parses the xml document from the url 
        /// </summary>
        WeatherData ParseDocumentCurrent();
        List<WeatherData> ParseDocumentFuture(double days);
    }
}
