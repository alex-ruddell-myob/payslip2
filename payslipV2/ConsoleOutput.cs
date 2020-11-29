using System;
using System.Collections.Generic;

namespace payslipV2
{
    class ConsoleOutput : IOutput
    {
        public void PrintPayslip(List<Payslip> payslips)
        {
            // Print payslip as per kata specification
            foreach (var payslip in payslips)
            {
                Console.WriteLine("\nYour payslip has been generated! \n");
                Console.WriteLine("Name: " + payslip.Name);
                Console.WriteLine("Pay Period: " + payslip.PayPeriod);
                Console.WriteLine("Gross Income: " + payslip.MonthlyGrossIncome);
                Console.WriteLine("Income Tax: " + payslip.MonthlyTax);
                Console.WriteLine("Net Income: " + payslip.MonthlyNetIncome);
                Console.WriteLine("Super: " + payslip.MonthlySuper);
            }
            
            Console.WriteLine("\nThank you for using MYOB!");
        }
    }
}