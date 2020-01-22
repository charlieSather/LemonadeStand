using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    public class Day
    {
        public Weather weather { get; set; }
        public List<Customer> customers { get; set; }
        public List<Customer> customersLeft;
        public string name;

        public Day(string name)
        {
            weather = new Weather();
            customers = new List<Customer>();
            customersLeft = new List<Customer>();
            this.name = name;
            SetCustomers();
        }
        public void SetCustomers()
        {
            int numOfCustomers = weather.DetermineNumberOfCustomers();

            for (int i = numOfCustomers; i >= 1; i--)
            {
                customers.Add(new Customer($"Customer {i}"));
                customersLeft.Add(new Customer($"Customer {i}"));
            }
        }
        public void ClearCustomers()
        {
            customers.Clear();
            customersLeft.Clear();
        }
        public void SetRealCustomers()
        {
            ClearCustomers();
            int numOfCustomers = weather.DetermineRealNumberOfCustomers();

            for (int i = numOfCustomers; i >= 1; i--)
            {
                customers.Add(new Customer($"Customer {i}"));
                customersLeft.Add(new Customer($"Customer {i}"));
            }
        }

    }
}
