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

        static void Main(string[] args)
        {
            bool run = Initialise(args);
            if (!run) return;

            List<EmployeeData> employees = _systemInput.ReadData();
            
            var payslips = new List<Payslip>();
            
            foreach (var employee in employees)
            {
                payslips.Add(_financialCalculator.GeneratePayslip(employee));
            }
            
            _systemOutput.PrintPayslip(payslips);
        }

        static bool Initialise(string[] args)
        {
            // Check arguments
            if (args.Length != 2)
            {
                Console.WriteLine("Incorrect number of program input arguments. Please enter an input and output" +
                                  " argument before running the program.");
                return false;
            }
            
            // Initialise system input
            if (args[0] == "Console")
            {
                _systemInput = new ConsoleInput();
            }
            else if (File.Exists(args[0])) 
            { 
                _systemInput = new CSVInput(args[0]);    
            }
            else
            {
                Console.WriteLine("File does not exist.");
                return false;
            }
            
            // Initialise system output
            if (args[1] == "Console")
            {
                _systemOutput = new ConsoleOutput();
            }
            else
            {
                _systemOutput = new CSVOutput(args[1]);
            }

            return true;
        }
    }
}