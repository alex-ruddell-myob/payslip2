using System;
using System.Collections.Generic;
using System.IO;

namespace payslipV2
{
    class CSVInputOutput : IInputOutput
    {
        private string _filepath;
        
        public List<EmployeeData> ReadData()
        {
            // Read from CSV file
            Console.WriteLine("Please type the filepath that you would like to read from...\n");
            Console.WriteLine("EG: /Users/Alex.Ruddell/Documents/payslipV2/payslip.csv");
            _filepath = Console.ReadLine();
            
            var FileReader = new StreamReader(_filepath);
            List<string> csvData = new List<string>();
            
            string line = FileReader.ReadLine(); // Read headings line

            while (!FileReader.EndOfStream)
            {
                line = FileReader.ReadLine();
                csvData.Add(line);
            }

            List<EmployeeData> EmployeeList = new List<EmployeeData>();
            EmployeeData Employee = new EmployeeData();
            
            foreach (var item in csvData)
            {
                string[] values = item.Split(","); 
                Employee = new EmployeeData();
                Employee.Name = values[0] + " " + values[1];
                Employee.AnnualSalary = Double.Parse(values[2]);
                Employee.SuperRate = Double.Parse(values[3].TrimEnd('%'));
                Employee.PayPeriod = values[4] + " - " + values[5];
                
                EmployeeList.Add(Employee);
            }

            return EmployeeList;
        }

        public void PrintPayslip(List<Payslip> Payslips)
        {
            string filepath = "/Users/Alex.Ruddell/Documents/payslipV2/payslip.csv"; // absolute!
            Console.WriteLine("\nYour CSV is being written to:\n" + String.Format(filepath));
            Console.WriteLine("\nWriting...");
            
            var FileWriter = new StreamWriter(filepath);
            // Write initial line
            var titleLine = "name,pay period,gross income,income tax,net income,super";
            FileWriter.WriteLine(titleLine);
            FileWriter.Flush();
            
            // Write data line for each payslip
            foreach (Payslip Payslip in Payslips)
            {
                string dataLine = Payslip.Name + "," + Payslip.PayPeriod + "," + Payslip.MonthlyGrossIncome +
                                  "," + Payslip.MonthlyTax + "," + Payslip.MonthlyNetIncome + "," + Payslip.MonthlySuper;
                FileWriter.WriteLine(dataLine);
                FileWriter.Flush();    
            }
            
            // Write final line to console
            Console.WriteLine("\nYour payslip has been generated!");
            Console.WriteLine("\nThank you for using MYOB!");
        }

        public CSVInputOutput()
        {
            Console.WriteLine("Welcome to the payslip generator! Get ready for the most fun you've had ever!!!");
        }

        /*
        ~CSVInputOutput()
        {
            Console.WriteLine("\nThank you for using MYOB!");
        }
        */
    }
}