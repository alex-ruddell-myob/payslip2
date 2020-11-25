using System;

namespace payslipV2
{
    class Program
    {
        public static IInputOutput SystemInputOutput = new CSVInputOutput();
        public static FinancialCalculator FinancialCalculator = new FinancialCalculator();
        
        static void Main(string[] args)
        {
            // Read Data
            EmployeeData Employee = SystemInputOutput.ReadData();

            Payslip Payslip = FinancialCalculator.GeneratePayslip(Employee);
            
            // Print data
            SystemInputOutput.PrintPayslip(Payslip);
        }
    }
}