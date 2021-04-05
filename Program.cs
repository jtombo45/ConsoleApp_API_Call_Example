using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ConsoleApp_API_Call_Example;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Security.Policy;

namespace ConsoleApp_API_Call_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";
            List<string> list = new List<string>();
            //GeoInfo parser = new GeoInfo();

            string city = "Phoenix";


            string url = "https://api.waqi.info/feed/" + city + "/?token=392e0da0a4b07ae7cd44f8e372203d50b70d71e0";
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(url);
                Console.WriteLine(json + "\n\n\n");
                //Console.WriteLine(json);
                Root1 parser = JsonConvert.DeserializeObject<Root1>(json);
                //Console.WriteLine(myDeserializedClass.results[0].citySalesTax);
                //Console.WriteLine(parser.status);
                if (parser.status == "ok")
                {
                    list.Add("The average air quality index (AQI), which ranges from a scale of 0-500 where the higher the number, the greater the level of air pollution and " +
                        "the greater the health concern, of " + parser.data.city.name + " is " + parser.data.aqi + ".");
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                result += list[i];
            }
            Console.WriteLine("\nResult = " + result);
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Attribution
        {
            public string url { get; set; }
            public string name { get; set; }
        }

        public class City
        {
            public List<double> geo { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Co
        {
            public double v { get; set; }
        }

        public class H
        {
            public decimal v { get; set; }
        }

        public class No2
        {
            public double v { get; set; }
        }

        public class O3
        {
            public double v { get; set; }
        }

        public class P
        {
            public decimal v { get; set; }
        }

        public class Pm10
        {
            public decimal v { get; set; }
        }

        public class Pm25
        {
            public decimal v { get; set; }
        }

        public class So2
        {
            public double v { get; set; }
        }

        public class T
        {
            public decimal v { get; set; }
        }

        public class W
        {
            public double v { get; set; }
        }

        public class Iaqi
        {
            public Co co { get; set; }
            public H h { get; set; }
            public No2 no2 { get; set; }
            public O3 o3 { get; set; }
            public P p { get; set; }
            public Pm10 pm10 { get; set; }
            public Pm25 pm25 { get; set; }
            public So2 so2 { get; set; }
            public T t { get; set; }
            public W w { get; set; }
        }

        public class Time
        {
            public string s { get; set; }
            public string tz { get; set; }
            public decimal v { get; set; }
            public DateTime iso { get; set; }
        }

        public class O32
        {
            public decimal avg { get; set; }
            public string day { get; set; }
            public decimal max { get; set; }
            public decimal min { get; set; }
        }

        public class Pm102
        {
            public decimal avg { get; set; }
            public string day { get; set; }
            public decimal max { get; set; }
            public decimal min { get; set; }
        }

        public class Pm252
        {
            public decimal avg { get; set; }
            public string day { get; set; }
            public decimal max { get; set; }
            public decimal min { get; set; }
        }

        public class Uvi
        {
            public decimal avg { get; set; }
            public string day { get; set; }
            public decimal max { get; set; }
            public decimal min { get; set; }
        }

        public class Daily
        {
            public List<O32> o3 { get; set; }
            public List<Pm102> pm10 { get; set; }
            public List<Pm252> pm25 { get; set; }
            public List<Uvi> uvi { get; set; }
        }

        public class Forecast
        {
            public Daily daily { get; set; }
        }

        public class Debug
        {
            public DateTime sync { get; set; }
        }

        public class Data
        {
            public decimal aqi { get; set; }
            public decimal idx { get; set; }
            public List<Attribution> attributions { get; set; }
            public City city { get; set; }
            public string dominentpol { get; set; }
            public Iaqi iaqi { get; set; }
            public Time time { get; set; }
            public Forecast forecast { get; set; }
            public Debug debug { get; set; }
        }

        public class Root1
        {
            public string status { get; set; }
            public Data data { get; set; }
        }


    }
}
