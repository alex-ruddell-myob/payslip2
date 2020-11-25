using System;

namespace payslipV2
{
    class Program
    {
        public static IInputOutput SystemConsoleInputOutput = new ConsoleInputOutput();
        public static FinancialCalculator FinancialCalculator = new FinancialCalculator();
        
        static void Main(string[] args)
        {
            // Read Data
            EmployeeData Employee = SystemConsoleInputOutput.ReadData();

            Payslip Payslip = FinancialCalculator.GeneratePayslip(Employee);
            
            // Print data
            SystemConsoleInputOutput.PrintPayslip(Payslip);
        }
    }
}