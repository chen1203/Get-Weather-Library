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
            private double dayNum; 
            private DateTime fromDate; 
            private DateTime toDate; 

        //counstructor for current weather
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


        public WeatherData() { }

        //constructor for future 3-5 days weather 
        public WeatherData(string city, string country, 
                  double temp, double minTemp, double maxTemp, string unitTemp,
                   string windDesc, DateTime fromDate, DateTime toDate, double dayNum)
        {
            City = city;
            Country = country;
            Temp = temp;
            MinTemp = minTemp;
            MaxTemp = maxTemp;
            UnitTemp = unitTemp;
            WindDesc = windDesc;
            DayNum = dayNum;
            FromDate = fromDate;
            ToDate = toDate;
            DayNum = dayNum;
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

            public double DayNum //atalia
            {
                get { return dayNum; }
                set
               {
                    if (dayNum < 3 || dayNum > 5)
                    {
                        Console.WriteLine("we can provide you future weather only for the coming 3-5 days");
                    }
                    else { dayNum = value; }
                }

            }
            public DateTime FromDate //atalia
            {
                get { return fromDate; }
                set { fromDate = value; }
            }
            public DateTime ToDate //atalia
            {
                get { return toDate; }
                set { toDate = value; }
            }

        // ToString Method different between current weather to future weather
        override public string ToString()
            {
            if (dayNum <=0) //for current weather
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

            else //for future weather
                {
                    return "\n*** Weather Data for: " +DayNum+ "days ***" + " "+ " FromDate "+ FromDate + " ToDate " + ToDate + "-" + '\n' +
                        "\nCity : " + City +
                        "\nCountry : " + Country +
                        "\nTemperature : " + Temp +
                        "\nMinimum temperature : " + MinTemp +
                        "\nMaximun temperature : " + MaxTemp +
                        "\nUnitTemp : " + UnitTemp +
                        "\nWind description: " + WindDesc + "\n";
                }

            }
        }
}
