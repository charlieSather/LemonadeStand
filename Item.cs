using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    abstract class Item
    {
        //Each of our inventory items are children of our abstract item class
        //This follows the Liskov Substitution principle because each class
        //acts as a substitute for the item class without any need for changes
        //in logic.

        public string name;

        public Item()
        {

        }


    }
}
