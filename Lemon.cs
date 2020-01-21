using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    
    class Lemon : Item
    {
        private int shelfLife;


        public Lemon()
        {
            name = "Lemon";
            shelfLife = 2;
        }

        public void DecrementShelfLife()
        {
            shelfLife--;
        }

        //This method utilizes the single use principle of SOLID.
        //Its only use is to determine if a given lemon has expired or not.
        public bool Expired()
        {
            return shelfLife < 1 ? true : false;
        }
    }
}
