using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using payslipV2;
using System;

namespace PayslipTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void FinanceTest1()
        {
            // Test prescribed by payslip kata
            Finance finance = new Finance();
            double expected = 922;
            double result = finance.CalculateMonthlyTax(60050);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FinanceTest2()
        {
            // Test prescribed by payslip kata
            Finance finance = new Finance();
            double expected = 2669;
            double result = finance.CalculateMonthlyTax(120000);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FinanceTestEdge1()
        {
            // Edge case testing
            Finance finance = new Finance();

            double expected = 0;
            double result = finance.CalculateMonthlyTax(0);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FinanceTestEdge2()
        {
            // Edge case testing
            Finance finance = new Finance();

            double expected = 0;
            double result = finance.CalculateMonthlyTax(18200);

            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void FinanceTestEdge3()
        {
            // Edge case testing
            Finance finance = new Finance();

            double expected = Math.Round(0.19);
            double result = finance.CalculateMonthlyTax(18201);

            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void FinanceTestEdge4()
        {
            // Edge case testing
            Finance finance = new Finance();

            double expected = Math.Round(3572.0 / 12);
            double result = finance.CalculateMonthlyTax(37000);

            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void FinanceTestEdge5()
        {
            // Edge case testing
            Finance finance = new Finance();

            double expected = Math.Round(19822.0 / 12);
            double result = finance.CalculateMonthlyTax(87000);

            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void FinanceTestEdge6()
        {
            // Edge case testing
            Finance finance = new Finance();

            double expected = Math.Round(19822.37 / 12);
            double result = finance.CalculateMonthlyTax(87001);

            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void FinanceTestEdge7()
        {
            // Edge case testing
            Finance finance = new Finance();

            double expected = Math.Round(54232.0 / 12);
            double result = finance.CalculateMonthlyTax(180000);

            Assert.AreEqual(expected, result);
        }
    }
}