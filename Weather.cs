using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    class Weather
    {
        public string condition { get; set; }
        public int temperature { get; set; }
        List<string> weatherConditions;
        public string predictedForecast { get; set; }

        public Weather()
        {
            weatherConditions = new List<string>
            {
                "Sunny",
                "Cloudy",
                "Rainy",
                "Stormy",
                "Snowing",
                "Windy",
                "Icy",
            };
            SetRandomCondition();
            SetRandomTemperature();

            //TODO
            predictedForecast = "Sunny";



        }
        
        public void SetRandomCondition()
        {
            Random rand = new Random();

            condition = weatherConditions[rand.Next(0, weatherConditions.Count)]; 
        }

        public void SetTemperature(int temperature)
        {
            this.temperature = temperature;
        }

        public void SetRandomTemperature()
        {
            Random rand = new Random();
            switch (condition)
            {
                case ("Sunny"):
                    temperature = rand.Next(70, 81);
                    break;
                case ("Cloudy"):
                    temperature = rand.Next(60, 71);
                    break;
                case ("Rainy"):
                    temperature = rand.Next(40, 61);
                    break;
                case ("Stormy"):
                    temperature = rand.Next(45, 66);
                    break;
                case ("Snowing"):
                    temperature = rand.Next(0, 33);
                    break;
                case ("Windy"):
                    temperature = rand.Next(70, 81);
                    break;
                case ("Icy"):
                    temperature = rand.Next(-10, 21);
                    break;
                default:
                    Console.WriteLine("Couldn't set temp");
                    break;
            }

        }

        






    }
}
