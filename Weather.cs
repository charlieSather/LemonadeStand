using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace LemondeStandProject
{
    class Weather
    {
        readonly string API_KEY = "3b17e245d06ca8548f65bcce526e7b06";

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

            SetWeatherForeast();
        }
        
        public void SetWeatherForeast()
        {
            string randCondition = GetRandomWeatherCondition();
            predictedForecast = "" + randCondition + " " + RandomTemperature(randCondition);
        }

        public string GetRandomWeatherCondition()
        {
            return weatherConditions[MyRandom.Next(0, weatherConditions.Count)];
        }

        public void SetTodaysWeather()
        {
            string[] forecastSplit = predictedForecast.Split();

            if(MyRandom.Next(10) < 2)
            {
                condition = GetRandomWeatherCondition();
                temperature = RandomTemperature(condition);
            }
            else
            {
                condition = forecastSplit[0];
                temperature = MyRandom.Next(-5, 5) + Int32.Parse(forecastSplit[1]);
            }

            this.temperature = temperature;
            SetBuyChance();
        }
        public int DetermineNumberOfCustomers()
        {
            int numCustomers = 0;

            string[] splitForecast = predictedForecast.Split();

            switch (splitForecast[0])
            {
                case ("Sunny"):
                    numCustomers = 50;
                    break;
                case ("Cloudy"):
                    numCustomers = 40;
                    break;
                case ("Rainy"):
                    numCustomers = 15;
                    break;
                case ("Stormy"):
                    numCustomers = 5;
                    break;
                case ("Snowing"):
                    numCustomers = 5;
                    break;
                case ("Windy"):
                    numCustomers = 20;
                    break;
                case ("Icy"):
                    numCustomers = 10;
                    break;
                default:
                    numCustomers = 20;
                    break;
            }

            return numCustomers;
        }
        public async void SetRealTimeWeather(string city)
        {
            HttpClient client = new HttpClient();
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&APPID={API_KEY}&units=imperial";
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                CurrentWeather weather = JsonConvert.DeserializeObject<CurrentWeather>(jsonResult);
                condition = weather.weather[0].description;
                temperature = (int)weather.main.temp;
            }
            else
            {
                Console.WriteLine("Catastrophic Failure");
            }
            predictedForecast = condition + " " + temperature;
        }
        public int RandomTemperature(string currentCondition)
        {
            int temp = 0;

            switch (currentCondition)
            {
                case ("Sunny"):
                    temp = MyRandom.Next(75, 96);
                    break;
                case ("Cloudy"):
                    temp = MyRandom.Next(65, 75);
                    break;
                case ("Rainy"):
                    temp = MyRandom.Next(50, 65);
                    break;
                case ("Stormy"):
                    temp = MyRandom.Next(45, 61);
                    break;
                case ("Snowing"):
                    temp = MyRandom.Next(0, 33);
                    break;
                case ("Windy"):
                    temp = MyRandom.Next(40, 75);
                    break;
                case ("Icy"):
                    temp = MyRandom.Next(-10, 21);
                    break;
                default:
                    break;
            }
            return temp;
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
            else if(temperature >= 50 && temperature < 60)
            {
                buyChance = 60;
            }
            else if (temperature >= 40 && temperature < 50)
            {
                buyChance = 50;
            }
            else
            {
                buyChance = 40;
            }

        }
        
    }
}
