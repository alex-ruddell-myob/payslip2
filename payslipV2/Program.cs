using System;
using System.Collections.Generic;
using System.IO;

namespace payslipV2
{
    class Program
    {
        private static IInput _systemInput;
        private static IOutput _systemOutput;
        private static FinancialCalculator _financialCalculator = new FinancialCalculator();
        private static bool _run = true;
        
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                // Connect system input and output interfaces
                _systemInput = IInput.ConnectInput(args[0]);
                _systemOutput = IOutput.ConnectOutput(args[1]);
            }
            else
            {
                Console.WriteLine("Incorrect number of program input arguments. Please enter an input and output" +
                                        " argument before running the program.");
                return;
            }
            
            List<EmployeeData> employees = new List<EmployeeData>();
            try
            {   // TODO(Alex): Put this somewhere earlier and better, exit as early as possible,
                // Use function object.validate, could also do in constructor?
                employees = _systemInput.ReadData();
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
            
            _systemOutput.PrintPayslip(payslips);

        }
    }
}