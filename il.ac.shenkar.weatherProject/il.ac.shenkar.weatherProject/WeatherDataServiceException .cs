using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace il.ac.shenkar.weatherProject
{
    public class WeatherDataServiceException : ApplicationException
    {
        // throw exception if the location is not exsist - to check!!! 
        public WeatherDataServiceException(string str) : base(str)
        {

        }
    }
}
