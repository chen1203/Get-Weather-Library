
namespace il.ac.shenkar.weatherProject
{
    /// <summary>
    /// This class describes a location by city and country
    /// </summary>
    public class Location
    {
        private string _city, _country;
       
        /// <summary>
        /// Location constructor
        /// </summary>
        /// <param name="city"></param>
        /// <param name="country"></param>
        public Location(string city, string country)
        {
            City = city;
            Country = country;
        }

        /// <summary>
        /// This property refers to the city's name 
        /// </summary>
        public string City
        {
            get { return _city; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _city = value;
                }
                else
                {
                    throw new WeatherDataServiceException("city's name is empty");
                }
            }
        }

        /// <summary>
        /// This property refers to the country's name
        /// </summary>
        public string Country
        {
            get { return _country; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _country = value;
                }
                else
                {
                    throw new WeatherDataServiceException("country's name is empty");
                }
            }
        }

        /// <summary>
        /// Override the ToString method 
        /// </summary>
        /// <returns> String describing the choosen location </returns>
        public override string ToString()
        {
            return "City : " + City + ", Country : " + Country + '\n';
        }
    }
}
