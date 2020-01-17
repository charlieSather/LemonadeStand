using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    class Wallet
    {
        private double money;
        public double Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }

        public Wallet(double money)
        {
            Money = money;
        }

        public void SpendMoney(double moneySpent)
        {
            Money -= moneySpent;
        }

        public bool CheckMoney(double cost)
        {
            if (cost > money)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
