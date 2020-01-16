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
        public int buyChance { get;  set; }

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
            condition = GetRandomWeatherCondition();
            SetRandomTemperature();
            predictedForecast = GetRandomWeatherCondition();
            SetBuyChance();
        }
        
        public string GetRandomWeatherCondition()
        {
            // Random rand = new Random();

            // return weatherConditions[rand.Next(0, weatherConditions.Count)];       
            return weatherConditions[MyRandom.Next(0, weatherConditions.Count)];             

        }

        public void SetTemperature(int temperature)
        {
            this.temperature = temperature;
        }

        public void SetRandomTemperature()
        {
            //Random rand = new Random();
            switch (condition)
            {
                case ("Sunny"):
                   // temperature = rand.Next(75, 96);
                    temperature = MyRandom.Next(75, 96);
                    break;
                case ("Cloudy"):
                   // temperature = rand.Next(65, 75);
                    temperature = MyRandom.Next(65, 75);
                    break;
                case ("Rainy"):
                    //temperature = rand.Next(50, 65);
                    temperature = MyRandom.Next(50, 65);
                    break;
                case ("Stormy"):
                    //temperature = rand.Next(45, 61);
                    temperature = MyRandom.Next(45, 61);
                    break;
                case ("Snowing"):
                    //temperature = rand.Next(0, 33);
                    temperature = MyRandom.Next(0, 33);
                    break;
                case ("Windy"):
                    //temperature = rand.Next(40, 75);
                    temperature = MyRandom.Next(40, 75);
                    break;
                case ("Icy"):
                   // temperature = rand.Next(-10, 21);
                    temperature = MyRandom.Next(-10, 21);
                    break;
                default:
                    //Interface.SetTempError
                    break;
            }
        }

        public void SetBuyChance()
        {

            if(temperature >= 90)
            {
                buyChance = 100;
            }
            else if(temperature >= 80 && temperature < 90)
            {
                buyChance = 90;
            }
            else if (temperature >= 70 && temperature < 80)
            {
                buyChance = 80;
            }
            else if(temperature >= 60 && temperature < 70)
            {
                buyChance = 70;
            }

            
        }
        
    }
}
