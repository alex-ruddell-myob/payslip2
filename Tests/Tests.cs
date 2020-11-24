using System;
using NUnit.Framework;
using payslipV2

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void PassingTest()
        {
            var f = new Finance();
            //Assert.AreEqual(0, .CalculateMonthlyTax(0));
        }

        [Test]
        public void Test2()
        {
            Assert.True(true);
        }
    }
}