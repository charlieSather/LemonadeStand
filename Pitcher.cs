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

        public Pitcher()
        {
            cupsLeftInPitcher = 15;
        }

        public void PourCup(Inventory inventory)
        {
            cupsLeftInPitcher--;

            inventory.cups.RemoveAt(0);
        }
    }
}
