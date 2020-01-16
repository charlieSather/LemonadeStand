using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    class Pitcher
    {

        public int cupsLeftInPitcher;

        public Pitcher(int cupsLeft)
        {
            cupsLeftInPitcher = cupsLeft;
        }

        public void PourCup(Player player, Recipe recipe)
        {
            for(int i = 0; i < recipe.amountOfLemons; i++)
            {
                player.inventory.lemons.RemoveAt(0);
            }


            cupsLeftInPitcher--;
        }
    }
}
