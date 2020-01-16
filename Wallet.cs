using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemondeStandProject
{
    class Wallet
    {
        public double money;
        double Money;

        public Wallet(double money)
        {
            this.money = money;
            Money = money;
        }

        public void SpendMoney(double moneySpent)
        {
            money -= moneySpent;
            Money -= moneySpent;
        }
    }
}
