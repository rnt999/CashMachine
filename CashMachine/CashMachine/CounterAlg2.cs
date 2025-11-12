using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashMachine
{
    public class InteratorAlg2 : IMoneyInterator
    {
        private readonly int _priorityKey = 20;
        public KeyValuePair<int, int> GetKeyValuePair(IMoneyHolder moneyHolder, int amount)
        {
            if (amount >= _priorityKey && moneyHolder[_priorityKey] > 0)
            {
                return moneyHolder.GetAll().SingleOrDefault(p => p.Key == _priorityKey);
            }
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
