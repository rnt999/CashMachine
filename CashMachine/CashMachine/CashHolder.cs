using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashMachine
{
    public class CoinsHolder : IMoneyHolder
    {
        private readonly IDictionary<int, int> _coins = new Dictionary<int, int>();

        public int this[int key]
        {
            get { return _coins[key]; }

            set { _coins[key] = value; }
        }

        public IDictionary<int, int> GetAll() {
            return _coins;
        }

        public decimal GetTotalSum()
        {
            return _coins.Sum(a => a.Key * a.Value) / 100.00m ;
        }
    }

    public class NotesHolder : IMoneyHolder
    {
        private readonly IDictionary<int, int> _notes = new Dictionary<int, int>();

        public int this[int key]
        {
            get { return _notes[key]; }

            set { _notes[key] = value; }
        }

        public IDictionary<int, int> GetAll()
        {
            return _notes;
        }
        public decimal GetTotalSum()
        {
            return _notes.Sum(a => a.Key * a.Value);
        }
    }   
}
