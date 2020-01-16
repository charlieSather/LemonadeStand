using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    static class MyRandom
    {
        readonly static Random rand = new Random();

        public static int Next(int range)
        {
            return rand.Next(range);
        }

        public static int Next(int minValue, int maxValue) 
        { 
            return rand.Next(minValue, maxValue); 
        }

    }
}
