
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
        /// This property refers to the location city
        /// </summary>
        public string City
        {
            get { return _city; }
            set
            {
                if (value != null)
                {
                    _city = value;
                }
                else
                {
                    throw new WeatherDataServiceException("location city is null");
                }
            }
        }

        /// <summary>
        /// This property refers to the location country
        /// </summary>
        public string Country
        {
            get { return _country; }
            set
            {
                if (value != null)
                {
                    _country = value;
                }
                else
                {
                    throw new WeatherDataServiceException("location country is null");
                }
            }
        }

        /// <summary>
        /// Override the ToString method 
        /// </summary>
        /// <returns> String describing the location </returns>
        public override string ToString()
        {
            return "Location - \nCity : " + City + ", Country : " + Country + '\n';
        }
    }
}
