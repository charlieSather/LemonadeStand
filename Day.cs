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
            SetCustomers();

        }

        public void SetCustomers()
        {
            int numOfCustomers = weather.DetermineNumberOfCustomers();

            for (int i = 1; i <= numOfCustomers; i++)
            {
                customers.Add(new Customer($"Customer {i}"));
            }
        }
        public void SetCustomers2()
        {
            int numOfCustomers = weather.DetermineNumberOfCustomers();

            for (int i = 1; i <= numOfCustomers; i++)
            {
                customers.Add(new Customer($"Customer {i}"));
            }
        }



    }
}
