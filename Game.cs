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
                Day day = new Day();
                week.Add(day);
            }
        }
        
        public void CheckPlayers()
        {
            players = Interface.GetPlayers();

            switch(players)
            {
                case 1:
                    string name = Interface.GetName(1);
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

        public void WorkDay(Day day, Player player)
        {
            foreach(Customer customer in day.customers)
            {
                if(customer.CheckIfBuy(day.weather, player.recipe))
                {
                    customer.BuyLemonade(player);
                }
                if(player.inventory.CheckInventory(player.recipe))
                {
                    break;
                }
            }
        }

        public void GameOver(Player player)
        {
            Interface.GameOver(player);

        }

        public void RunDay(Player player)
        {
            bool dayOver = false;
            store.Shop(player);
            player.SetRecipe();
            do
            {
                player.FillNewPitcher();
                WorkDay(week[currentDay], player);


                if (player.inventory.CheckInventory(player.recipe))
                {
                    dayOver = true;
                }
                Console.WriteLine(player.wallet.money);
                Console.ReadLine();
            } while (dayOver);
           

        }
        public void RunGame()
        {
            CheckPlayers();

            do
            {
                RunDay(player1);

                if (players == 2)
                {
                    RunDay(player2);
                }

                Console.WriteLine();
                currentDay++;
            } while (currentDay <= weekLength);

            GameOver(player1);
        }
    }
}
