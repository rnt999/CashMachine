using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashMachine
{
    public class InteratorAlg1 : IMoneyIterator
    {
        public KeyValuePair<int, int> GetKeyValuePair(IMoneyHolder moneyHolder, int amount)
        {
            foreach (var money in moneyHolder.GetAll())
            {
                if (amount >= money.Key && money.Value > 0)
                {
                    return money;
                }
            }
            throw new Exception("Not enough coins or notes!");
        }

    }
}
