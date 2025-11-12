using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashMachine
{
    public class ConsoleViewer : IResultViewer
    {
        public void DisplayResults(WithdrawMoneyResults results, decimal balance)
        {
            Console.Write(string.Join(", ", from note in results.Notes select $"£{note.Key}*{note.Value}"));
            Console.Write(string.Join(", ", from coin in results.Coins select $"£{coin.Key / 100.00}*{coin.Value}"));
            Console.WriteLine();
            Console.WriteLine($"£{balance} balance");
        }

        public void ShowMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
