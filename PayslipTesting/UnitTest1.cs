using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using payslipV2;
using System;
using System.Security.Cryptography;

namespace PayslipTesting
{
    public class FinanceTests
    {
        private FinancialCalculator _financialCalculator;

        [SetUp]
        public void Setup()
        {
            _financialCalculator = new FinancialCalculator();
        }
        
        // Add comments!
        // Tests prescribed by payslip kata
        [TestCase(60050, 922)]
        [TestCase(120000, 2669)]
        // Edge case self-written tests
        [TestCase(0, 0)]
        [TestCase(18200, 0)]
        [TestCase(18201, 0)]
        [TestCase(37000, 298)]
        [TestCase(87000, 1652)]
        [TestCase(87001, 1652)]
        [TestCase(180000, 4519)]
        public void TaxCalculatorTest(double annualSalary, double expectedMonthlyTax)
        {
            double calculatedTax = _financialCalculator.CalculateMonthlyTax(annualSalary);

            Assert.AreEqual(expectedMonthlyTax, calculatedTax);
        }
    }
}