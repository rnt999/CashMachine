namespace CashMachine
{
    public interface IResultViewer
    {
        void DisplayResults(WithdrawMoneyResults results, decimal balance);
        void ShowMessage(string msg);
    }
}