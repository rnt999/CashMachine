using CashMachine.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashMachine
{
    public class Account : IAccount
    {
        private readonly IMoneyHolder _coinsHolder;
        private readonly IMoneyHolder _notesHolder;
        private readonly IMoneyIterator _notesIterator;
        private readonly IMoneyIterator _coinsIterator;

        public Account(IMoneyHolder notesHolder, IMoneyHolder coinsHolder, IMoneyIterator notesIterator,
            IMoneyIterator coinsIterator)
        {
            _coinsHolder = coinsHolder;
            _notesHolder = notesHolder;
            _notesIterator = notesIterator;
            _coinsIterator = coinsIterator;
        }

        public bool CanWithdraw(decimal amount)
        {
            return GetBalance() >= amount;
        }

        public decimal GetBalance()
        {
            decimal balance = _notesHolder.GetTotalSum();
            balance += _coinsHolder.GetTotalSum();
            return balance;
        }

        public WithdrawMoneyResults WithdrawMoney(decimal amount)
        {
            var money = amount.ConvertToMoney();
            return new WithdrawMoneyResults()
            {
                Notes = DispenseMoney(money.Notes, _notesIterator, _notesHolder),
                Coins = DispenseMoney(money.Coins, _coinsIterator, _coinsHolder)
            };
        }

        private Dictionary<int, int> DispenseMoney(int amount, IMoneyIterator iterator, IMoneyHolder moneyHolder)
        {
            var returnNotes = new Dictionary<int, int>();
            while (amount > 0)
            {
                var keyValue = iterator.GetKeyValuePair(moneyHolder, amount);

                int reminder = amount % keyValue.Key;
                int total = amount / keyValue.Key;
                if (total > keyValue.Value)
                {
                    total = total - keyValue.Value;
                    returnNotes.Add(keyValue.Key, keyValue.Value);
                    moneyHolder[keyValue.Key] = 0;
                    amount = reminder + total * keyValue.Key;
                }
                else
                {
                    returnNotes.Add(keyValue.Key, total);
                    moneyHolder[keyValue.Key] -= total;
                    amount -= keyValue.Key * total;
                }
            }

            return returnNotes;
        }
    }
}
