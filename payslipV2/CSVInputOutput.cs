using System;
using System.Collections.Generic;
using System.IO;

namespace payslipV2
{
    class CSVInputOutput : IInputOutput
    {
        CSVHandler _CSVHandler = new CSVHandler();
        
        private string _readpath;
        private string _writepath;

        public List<EmployeeData> ReadData()
        {
            List<EmployeeData> EmployeeList = new List<EmployeeData>();
            
            List<string> CSVData = _CSVHandler.GetData(_readpath);
            
            foreach (var row in CSVData)
            {
                EmployeeData Employee = _CSVHandler.ConvertToEmployee(row);
                EmployeeList.Add(Employee);
            }

            return EmployeeList;
        }

        public void PrintPayslip(List<Payslip> Payslips)
        {
            var FileWriter = new StreamWriter(_writepath);
            FileWriter.WriteLine("name,pay period,gross income,income tax,net income,super");
            FileWriter.Flush();
            
            // Write data line for each payslip
            foreach (Payslip Payslip in Payslips)
            {
                string dataLine = _CSVHandler.FormatPayslip(Payslip);
                FileWriter.WriteLine(dataLine);
                FileWriter.Flush();    
            }
            
            Console.WriteLine("\nYour payslip has been generated. Thank you for using MYOB!");
        }

        public CSVInputOutput()
        {
            Console.WriteLine("Welcome to the payslip generator! Get ready for the most fun you've had ever!!!");
            
            // Retrieve file paths on instantiation
            string basepath = _CSVHandler.GetBasePath();
            
            Console.Write("Please type the file name you would like to read...\nFile: " + basepath + ": ");
            _readpath =  Path.Combine(basepath, Console.ReadLine());
            
            Console.Write("Please type the file name you would like to write to...\nFile: " + basepath + ": ");
            _writepath = Path.Combine(basepath, Console.ReadLine());

        }
    }
}