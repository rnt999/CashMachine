using System;

namespace CashMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var _coins = new CoinsHolder();
            _coins[50] = 100;
            _coins[20] = 100;
            _coins[10] = 100;
            _coins[5] = 100;
            _coins[2] = 100;
            _coins[1] = 100;
            var _notes = new NotesHolder();
            _notes[50] = 50;
            _notes[20] = 50;
            _notes[10] = 50;
            _notes[5] = 50;
            _notes[2] = 100;
            _notes[1] = 100;

            IMoneyIterator alg1 = new InteratorAlg1();
            IMoneyIterator alg2 = new InteratorAlg2();

            var _continue = true;
            do
            {
                Console.WriteLine("Please select algorithm. Press 1 for Algorithm 1 and press 2 for Algorithm 2 ");            
                var notesAlg = int.Parse(Console.ReadLine()) == 1 ? alg1 : alg2;
                IResultViewer viewer = new ConsoleViewer();
                IAccount account = new Account(_notes, _coins, notesAlg, alg1);
                ICashier cashier = new Cashier(viewer, account);
                cashier.ShowBalance();
                Console.Write("Enter amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                cashier.WithdrawMoney(amount);
                Console.WriteLine("do you want to withdraw more cash ? ");
                Console.WriteLine("press y to continue ");
                char answer = char.Parse(Console.ReadLine());
                _continue = (answer == 'y');
            }
            while (_continue);
            
        }
    }
}
