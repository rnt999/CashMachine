using System.Collections.Generic;

namespace CashMachine
{
    public interface IMoneyInterator
    {
        KeyValuePair<int, int> GetKeyValuePair(IMoneyHolder moneyHolder, int amount);
    }
}