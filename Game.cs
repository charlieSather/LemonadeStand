using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using Newtonsoft.Json;

namespace LemondeStandProject
{
    class Game
    {
        Player player1;
        Player player2;
        Store store;
        List<Day> week;
        int currentDay = 0;
        int weekLength = 7;
        int players;
        readonly string API_KEY = "3b17e245d06ca8548f65bcce526e7b06";

        public Game()
        {
            week = new List<Day>();
            WeekSetup();
            store = new Store();
        }

        public void WeekSetup()
        {
            int apiChoice = Interface.PromptUserRealTimeWeatherSystem();

            for (int i = 0; i < weekLength; i++)
            {
                string name = "";
                switch(i)
                {
                    case 0:
                        name = "Monday";
                        break;
                    case 1:
                        name = "Tuesday";
                        break;
                    case 2:
                        name = "Wednesday";
                        break;
                    case 3:
                        name = "Thursday";
                        break;
                    case 4:
                        name = "Friday";
                        break;
                    case 5:
                        name = "Saturday";
                        break;
                    case 6:
                        name = "Sunday";
                        break;
                    default:
                        break;
                }
                Day day = new Day(name);
                if(name == "Monday" && apiChoice == 1)
                {
                    day.weather.SetRealTimeWeather("Milwaukee");
                }
                else
                {
                    day.weather.SetTodaysWeather();
                }
                week.Add(day);
            }
            if(apiChoice == 1)
            {
                SetWeeklyRealTimeForeCast("Milwaukee", week);
            }

        }
        public async void SetWeeklyRealTimeForeCast(string city, List<Day> week)
        {
            HttpClient client = new HttpClient();
            string url = $"http://api.openweathermap.org/data/2.5/forecast?q={city}&APPID={API_KEY}&units=imperial";
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                Forecast.Forecast forecast = JsonConvert.DeserializeObject<Forecast.Forecast>(jsonResult);
                int threeHourIncrement = 0;

               for(int i = 0;  i < week.Count - 1; i++)
                {
                    if(i == 0)
                    {
                        week[i].weather.SetRealWeatherForcast();
                        week[i].SetRealCustomers();
                    }
                    else
                    {
                        week[i].weather.SetWeatherForecast(forecast.list[threeHourIncrement].weather[0].description, (int) forecast.list[i].main.temp);
                        week[i].SetRealCustomers();
                        week[i].weather.SetTodaysWeather();
                        threeHourIncrement += 8;
                    }
                }
            }
            else
            {
                Console.WriteLine("Catastrophic Failure");
            }
        }
        public void CheckPlayers()
        {
            players = Interface.GetPlayers();
            string name;
            switch(players)
            {
                case 1:
                    name = Interface.GetName(1);
                    player1 = new Player(name);
                    break;
                case 2:
                    name = Interface.GetName(1);
                    player1 = new Player(name);
                    name = Interface.GetName(2);
                    player2 = new Player(name);
                    break;
                //case 3:
                //    name = Interface.GetName(1);
                //    player1 = new Player(name);
                //    player2 = new Computer();
                //    break;
                
            }
        }

        public void ServePitcher(Player player, Day day)
        {
            for (int i = day.customersLeft.Count - 1; i >= 0; i--)
            {
                if(player.pitcher.cupsLeftInPitcher == 0 || player.inventory.cups.Count == 0)
                {
                    break;
                }
                if(day.customersLeft[i].CheckIfBuy(day.weather, player.recipe))
                {
                    day.customers[i].BuyLemonade(player);
                    day.customersLeft.RemoveAt(i);
                }
                else
                {
                    day.customersLeft.RemoveAt(i);
                }
                
            }
        }


        public void RunDay(Player player, Day day)
        {
            int pitchersMade = 0;
            store.Shop(player, day);
            player.SetRecipe();

            Interface.StartDay(day, player);

            do
            {
                
                if (player.inventory.CheckInventory(player.recipe) || day.customersLeft.Count == 0 || player.inventory.cups.Count == 0)
                {
                    
                    if (player.inventory.CheckInventory(player.recipe))
                    {
                        Interface.NotEnoughIngredients();
                        break;
                    }
                    else if (day.customersLeft.Count == 0)
                    {
                        Interface.NoMoreCustomers();
                        break;
                    }
                    else if(player.inventory.cups.Count == 0)
                    {
                        Interface.NoMoreCups();
                        break;
                    }
                }

                if (player.pitcher == null || player.pitcher.cupsLeftInPitcher == 0)
                {
                    player.FillNewPitcher();
                    pitchersMade++;
                }
                    
                
                ServePitcher(player, week[currentDay]);

                

            } while (true);


            player.CalculateUsage(pitchersMade, store);
            if(player.pitcher != null)
            {
                player.pitcher.cupsLeftInPitcher = 0;
            }
            player.inventory.InventoryCheck(day.weather);
            Interface.EndOfDay(player, day);
            
        }
        public void RunGame()
        {
            CheckPlayers();

            do
            {
                if(players == 2) { Interface.StartTurn(player1); }
                
                player1.customersServed = 0;
                player1.profit = 0;
                RunDay(player1, week[currentDay]);

                if (players == 2)
                {
                    Interface.StartTurn(player2); 
                    player2.customersServed = 0;
                    player2.profit = 0;
                    week[currentDay].customersLeft.Clear();
                    week[currentDay].customersLeft.AddRange(week[currentDay].customers);
                    RunDay(player2, week[currentDay]);
                }

                if(player1.wallet.Money == 0)
                {
                    Interface.OutOfMoney(player1);
                    return;
                }

                if (players == 2 && player2.wallet.Money == 0)
                {
                    Interface.OutOfMoney(player2);
                    return;
                }

                currentDay++;
            } while (currentDay < weekLength);

            if(players == 1)
            {
                Interface.GameOver(player1);
            }
            else if(players == 2)
            {
                CheckWinner();
            }
        }

        public void CheckWinner()
        {
            if(player1.wallet.Money > player2.wallet.Money)
            {
                Interface.GameOver(player1, player2);
            }
            else
            {
                Interface.GameOver(player2, player1);
            }
        }
    }
}
