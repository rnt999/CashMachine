using System;
using System.Collections.Generic;
using System.Text;

namespace CashMachine.Extensions
{
    public static class Extensions
    {
        public static Money ConvertToMoney(this Decimal value)
        {
            return new Money()
            {
                Notes = (int)Math.Truncate(value),
                Coins = (int)((value - Math.Truncate(value)) * 100m)
            };
        }
    }


}
