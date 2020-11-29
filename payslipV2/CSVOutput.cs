using System;
using System.Collections.Generic;
using System.IO;

namespace payslipV2
{
    class CSVOutput : IOutput 
    {
        private readonly string _writePath;

        public void PrintPayslip(List<Payslip> Payslips)
        {
            var fileWriter = new StreamWriter(_writePath);
            fileWriter.WriteLine("name,pay period,gross income,income tax,net income,super");
            fileWriter.Flush();
            
            // Write data line for each payslip
            foreach (var payslip in Payslips)
            {
                var dataLine = CSVHandler.FormatPayslip(payslip);
                fileWriter.WriteLine(dataLine);
                fileWriter.Flush();    
            }

            var filepath =  Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            
            Console.WriteLine("\nYour payslip has been generated as a CSV at " + filepath + "/" + 
                              _writePath.TrimStart('/','.') + "\nThank you for using MYOB!");
        }

        public CSVOutput(string arg)
        {
            _writePath = arg;
        }
    }
}