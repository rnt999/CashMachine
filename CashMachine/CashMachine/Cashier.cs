using CashMachine.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashMachine
{
    public class Cashier : ICashier
    {
        private readonly IResultViewer _resultViewer;
        private readonly IAccount _account;

        public Cashier(IResultViewer resultViewer, IAccount account)
        {
            this._resultViewer = resultViewer;
            this._account = account;
        }
        public void WithdrawMoney(decimal amount)
        {
            if (_account.CanWithdraw(amount))
            {
                var returnMoney = _account.WithdrawMoney(amount);
                var balance = this._account.GetBalance();
                _resultViewer.DisplayResults(returnMoney, balance);
            }
            else {
                _resultViewer.ShowMessage("Not enouth funds!");
            }
            
        }

        public void ShowBalance()
        {
            _resultViewer.ShowMessage($"Available balance : {_account.GetBalance()}");
        }
    }
}
