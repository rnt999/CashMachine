using CashMachine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    public class AccountTest
    {
        IMoneyHolder _coins;
        IMoneyHolder _notes;
        [SetUp]
        public void Setup()
        {
            _coins = new CoinsHolder();
            _coins[50] = 100;
            _coins[20] = 100;
            _coins[10] = 100;
            _coins[5] = 100;
            _coins[2] = 100;
            _coins[1] = 100;
            _notes = new NotesHolder();
            _notes[50] = 50;
            _notes[20] = 50;
            _notes[10] = 50;
            _notes[5] = 50;
            _notes[2] = 100;
            _notes[1] = 100;
        }

        [Test]
        public void ShouldWithdrawAmountWhenInput120ForAlg1()
        {
            IMoneyIterator alg1 = new InteratorAlg1();
            IAccount account = new Account(_notes, _coins, alg1, alg1);
            var results = account.WithdrawMoney(120);

            Assert.AreEqual(results.Notes[50], 2);
            Assert.AreEqual(results.Notes[20], 1);
            Assert.AreEqual(account.GetBalance(), 4518);
        }

        [Test]
        public void ShouldWithdrawAmountWhenInput120ForAlg2()
        {
            IMoneyIterator alg1 = new InteratorAlg1();
            IMoneyIterator alg2 = new InteratorAlg2();
            IAccount account = new Account(_notes, _coins, alg2, alg1);
            var results = account.WithdrawMoney(120);

            Assert.AreEqual(results.Notes[20], 6);
            Assert.AreEqual(account.GetBalance(), 4518);
        }

        [Test]
        public void ShouldGetBalance()
        {
            IMoneyIterator alg1 = new InteratorAlg1();
            IAccount account = new Account(_notes, _coins, alg1, alg1);
            var results = account.GetBalance();
            Assert.AreEqual(results, 4638);
        }
    }
}