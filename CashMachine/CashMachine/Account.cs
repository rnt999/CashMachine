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
        private readonly IMoneyInterator _notesInterator;
        private readonly IMoneyInterator _coinsInterator;

        public Account(IMoneyHolder notesHolder, IMoneyHolder coinsHolder, IMoneyInterator notesInterator,
            IMoneyInterator coinsInterator)
        {
            this._coinsHolder = coinsHolder;
            this._notesHolder = notesHolder;
            this._notesInterator = notesInterator;
            this._coinsInterator = coinsInterator;
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
                Notes = dispenseMoney(money.Notes, _notesInterator, _notesHolder),
                Coins = dispenseMoney(money.Coins, _coinsInterator, _coinsHolder)
            };
        }

        private Dictionary<int, int> dispenseMoney(int amount, IMoneyInterator interator, IMoneyHolder moneyHolder)
        {
            var returnNotes = new Dictionary<int, int>();
            while (amount > 0)
            {
                var keyValue = interator.GetKeyValuePair(moneyHolder, amount);

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
