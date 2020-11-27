using System;
using System.Collections.Generic;
using System.IO;

namespace payslipV2
{
    class Program
    {
        private static IInputOutput _systemInputOutput;
        private static FinancialCalculator _financialCalculator = new FinancialCalculator();
        private static bool _run = true;
        
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                _systemInputOutput = new CSVInputOutput(args);
            }
            else
            {
                _systemInputOutput = new ConsoleInputOutput();
            }
            
            
            // Read Data
            List<EmployeeData> employees = new List<EmployeeData>();
            try
            { // put this somewhere earlier and better, exit as early as possible, object.validate, could also do in constructor
                employees = _systemInputOutput.ReadData();
            }
            catch ( FileNotFoundException )
            {
                Console.WriteLine("Input file not found. No payslip generated.");
                _run = false;
            }

            if (!_run) return;
            
            var payslips = new List<Payslip>();
            foreach (var employee in employees)
            {
                payslips.Add(_financialCalculator.GeneratePayslip(employee));
            }
            
            _systemInputOutput.PrintPayslip(payslips);

        }
    }
}