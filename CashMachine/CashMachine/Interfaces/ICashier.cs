namespace CashMachine
{
    public interface ICashier
    {
        void ShowBalance();
        void WithdrawMoney(decimal amount);
    }
}