using System;

namespace il.ac.shenkar.weatherProject
{
    class WeatherData
    {
        private string city;
        private string counrty;
        private string weatherValue;
        private double temp;
        private double minTemp;
        private double maxTemp;
        private string unitTemp;
        private DateTime lastUpdate;
        private string windDesc;

        public WeatherData(string city, string country, string weatherValue, 
                           double temp, double minTemp, double maxTemp, string unitTemp, 
                           DateTime lastUpdate, string windDesc)
        {
            City = city;
            Country = country;
            WeatherValue = weatherValue;
            Temp = temp;
            MinTemp = minTemp;
            MaxTemp = maxTemp;
            UnitTemp = unitTemp;
            LastUpdate = lastUpdate;
            WindDesc = windDesc;
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string Country
        {
            get { return counrty; }
            set { counrty = value; }
        }
        public string WeatherValue
        {
            get { return weatherValue; }
            set { weatherValue = value; }
        }
        public double Temp
        {
            get { return temp; }
            set { temp = value; }
        }
        public double MinTemp
        {
            get { return minTemp; }
            set { minTemp = value; }
        }
        public double MaxTemp
        {
            get { return maxTemp; }
            set { maxTemp = value; }
        }
        public string UnitTemp
        {
            get { return unitTemp; }
            set { unitTemp = value; }
        }
        public DateTime LastUpdate
        {
            get { return lastUpdate; }
            set { lastUpdate = value; }
        }
        public string WindDesc
        {
            get { return windDesc; }
            set { windDesc = value; }
        }
        override public string ToString()
        {
            return "\n*** Weather Data ***" + 
                "\nCity : " + City + 
                "\nCountry : " + Country + 
                "\nweather value : " + WeatherValue +
                "\nTemperature : " + Temp +
                "\nMinimum temperature : " + MinTemp +
                "\nMaximun temperature : " + MaxTemp +
                "\nUnitTemp : " + UnitTemp +
                "\nLast update : " + LastUpdate +
                "\nWind description: " + WindDesc + "\n";
        }
    }
}
