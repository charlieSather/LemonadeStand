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
        List<Day> week;
        int currentDay;
        int weekLength = 7;
        int players;
        bool dayOver = false;

        public Game(Player player1, Player player2)
        {
            WeekSetup();

            this.player1 = player1;
            this.player2 = player2;

        }

        public void WeekSetup()
        {
            for (int i = 0; i < weekLength; i++)
            {
                Day day = new Day();
                week.Add(day);
            }
        }
        
        public int CheckPlayers()
        {
            //players = INTERFACE.GET How many players
            return 1;
        }

        public void WorkDay(Day day, Player player)
        {
            foreach(Customer customer in day.customers)
            {
                if(customer.CheckIfBuy(day.weather, player.recipe.buyChance, player.recipe.pricePerCup))
                {

                }
            }
        }

        public void RunDay(Player player)
        {
            player.Setup();

            do
            {
                player.FillNewPitcher();

                do
                {

                    WorkDay(week[currentDay]);


                    if (player.inventory.CheckInventory(player.recipe))
                    {
                        dayOver = true;
                    }

                } while (player.pitcher.cupsLeftInPitcher > 0);
                if (dayOver)
                {
                    break;
                }
            } while (true);

            currentDay++;
        }
        public void RunGame()
        {
            CheckPlayers();



            
        }
    }
}
