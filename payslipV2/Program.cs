using System;
using System.Collections.Generic;

namespace payslipV2
{
    class Program
    {
        public static IInputOutput SystemInputOutput = new CSVInputOutput();
        public static FinancialCalculator FinancialCalculator = new FinancialCalculator();
        
        static void Main(string[] args)
        {
            // Read Data
            List<EmployeeData> Employees = SystemInputOutput.ReadData();

            // Generate all payslips
            List<Payslip> Payslips = new List<Payslip>();
            foreach (EmployeeData Employee in Employees)
            {
                Payslips.Add(FinancialCalculator.GeneratePayslip(Employee));
            }
            
            SystemInputOutput.PrintPayslip(Payslips);
        }
    }
}