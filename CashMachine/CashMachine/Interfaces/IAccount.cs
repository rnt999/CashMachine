namespace CashMachine
{
    public interface IAccount
    {
        bool CanWithdraw(decimal amount);
        decimal GetBalance();
        WithdrawMoneyResults WithdrawMoney(decimal amount);
    }
}