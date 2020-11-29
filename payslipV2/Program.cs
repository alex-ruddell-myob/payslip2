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
        
        
        private static IInputOutput _systemInput;
        private static IInputOutput _systemOutput;
        
        
        static void Main(string[] args)
        {
            
            // TODO(Alex) Make this simpler
            // e.g. _system.Initialise(args), house _systemInput and _systemOutput
            if (args.Length == 2)
            {
                if (args[0] == "Console")
                {
                    _systemInput = new ConsoleInputOutput();
                }
                else
                {
                    _systemInput = new CSVInputOutput(args);
                }

                if (args[1] == "Console")
                {
                    _systemOutput = new ConsoleInputOutput();
                }
                else
                {
                    _systemOutput = new CSVInputOutput(args);
                }
            }
            else
            {
                Console.WriteLine("Incorrect number of program input arguments. Please enter an input and output" +
                                        " argument before running the program.");
                return;
            }
            
            
            // Read Data
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