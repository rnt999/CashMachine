using System;
using System.Collections.Generic;
using System.Text;

namespace CashMachine
{
    public class MoneyValues
    {
        public int Denomination { get; set; }
        public int Total { get; set; }
    }

    public class WithdrawMoneyResults
    {
        public Dictionary<int, int> Notes { get; set; }
        public Dictionary<int, int> Coins { get; set; }
    }

    public class Money
    {
        public int Notes { get; set; }
        public int Coins { get; set; }
    }
}
