using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    class Day
    {
        public Weather weather { get; set; }
        public List<Customer> customers { get; set; }


        public Day()
        {
            weather = new Weather();
            customers = new List<Customer>();

            for(int i = 0; i < 25; i++)
            {
                customers.Add(new Customer($"Customer {i+ 1}"));
            }
        }




    }
}
