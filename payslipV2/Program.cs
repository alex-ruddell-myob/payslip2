using System;
using System.Collections.Generic;
using System.IO;

namespace payslipV2
{
    class Program
    {
        public static IInputOutput SystemInputOutput;
        public static FinancialCalculator FinancialCalculator = new FinancialCalculator();
        public static bool _run = true;
        
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                SystemInputOutput = new CSVInputOutput(args);
            }
            else
            {
                SystemInputOutput = new ConsoleInputOutput();
            }
            
            
            // Read Data
            List<EmployeeData> Employees = new List<EmployeeData>();
            try
            {
                Employees = SystemInputOutput.ReadData();
            }
            catch ( FileNotFoundException )
            {
                Console.WriteLine("Input file not found. No payslip generated.");
                _run = false;
            }

            if (_run)
            {
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
}