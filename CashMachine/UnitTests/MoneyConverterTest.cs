using CashMachine.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    public class MoneyConverterTest
    {

        [Test]
        [TestCase(10.45, 10, 45)]
        [TestCase(9.99, 9, 99)]
        public void ShouldConvertMoneyObject(decimal value, int expectedNote, int expectedCoin)
        {
            var result = value.ConvertToMoney();
            Assert.IsTrue(result.Notes == expectedNote);
            Assert.IsTrue(result.Coins == expectedCoin);
        }
    }
}
