using System;
using System.Collections.Generic;
using System.IO;

namespace payslipV2
{
    class CSVInputOutput : IInputOutput
    {
        private readonly string _readPath;
        private readonly string _writePath;

        public List<EmployeeData> ReadData()
        {
            var employeeList = new List<EmployeeData>();
            
            List<string> csvData = CSVHandler.GetData(_readPath);
            
            foreach (var row in csvData)
            {
                var employee = CSVHandler.ConvertToEmployee(row);
                employeeList.Add(employee);
            }

            return employeeList;
        }

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

        public CSVInputOutput(string[] args)
        {
            Console.WriteLine("Welcome to the payslip generator!");
            
            _readPath = args[0];
            _writePath = args[1];
        }
    }
}