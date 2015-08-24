using System;

namespace il.ac.shenkar.weatherProject
{
    class Location
    {
              private string name, country;

        //constructor
        public Location(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == "")
                { Console.WriteLine("please enter a city"); }
                else
                { name = value; }
            }
        }


        public string Country
        {
            get { return country; }
            set { country = value; }
        }


        //Get all in to string 
        public override string ToString()
        {
            return "Location: Name=" + Name +
                ", Country=" + Country + '\n';
        }
    }
}
