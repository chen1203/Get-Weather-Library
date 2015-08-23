
namespace il.ac.shenkar.weatherProject
{
    /// <summary>
    /// This interface defines the ParseDocument method 
    /// and its purpose is to get the data from and xml site
    /// </summary>
    interface IParser
    {
        /// <summary>
        /// Parses the xml document from the url 
        /// </summary>
        WeatherData ParseDocument();
    }
}
