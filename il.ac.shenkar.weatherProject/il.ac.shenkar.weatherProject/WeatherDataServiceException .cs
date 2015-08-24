using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace il.ac.shenkar.weatherProject
{
    public class WeatherDataServiceException : ApplicationException
    {
        public WeatherDataServiceException(string str) : base(str)
        {

        }
    }
}
