using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        

        public Game()
        {
            week = new List<Day>();
            WeekSetup();
            store = new Store();
        }

        public void WeekSetup()
        {
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
                day.weather.SetTodaysWeather();
                week.Add(day);
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

            player1.CalculateUsage(pitchersMade, store);
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
                    RunDay(player2, week[currentDay]);
                }

                if(player1.wallet.money == 0)
                {
                    Interface.OutOfMoney(player1);
                    return;
                }

                if (players == 2 && player2.wallet.money == 0)
                {
                    Interface.OutOfMoney(player2);
                    return;
                }

                currentDay++;
            } while (currentDay <= weekLength);

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
            if(player1.wallet.money > player2.wallet.money)
            {
                Interface.GameOver(player1);
            }
            else
            {
                Interface.GameOver(player2);
            }
        }
    }
}
