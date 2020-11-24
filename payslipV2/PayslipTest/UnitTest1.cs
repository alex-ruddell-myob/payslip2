using NUnit.Framework;
using payslipV2;

namespace PayslipTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var f = new Finance();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}