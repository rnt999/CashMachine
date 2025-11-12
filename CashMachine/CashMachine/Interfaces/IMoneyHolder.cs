using System.Collections.Generic;

namespace CashMachine
{
    public interface IMoneyHolder
    {
        int this[int key] { get; set; }
        IDictionary<int, int> GetAll();
        decimal GetTotalSum();
    }
}