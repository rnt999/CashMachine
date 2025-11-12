using System.Collections.Generic;

namespace CashMachine
{
    public interface IMoneyIterator
    {
        KeyValuePair<int, int> GetKeyValuePair(IMoneyHolder moneyHolder, int amount);
    }
}