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

        //The SpendMoney method follows the single use principle because
        //it is only used to remove the amount of money spent from the
        //money in your wallet.
        public void SpendMoney(double moneySpent)
        {
            Money -= moneySpent;
        }

    }
}
