using System;
using System.Collections.Generic;
using System.IO;

namespace payslipV2
{
    class CSVInputOutput : IInputOutput
    {
        private string _filepath;
        
        public EmployeeData ReadData()
        {
            // Read from CSV file
            Console.WriteLine("Please type the filepath that you would like to read from...\n");
            Console.WriteLine("EG: /Users/Alex.Ruddell/Documents/payslipV2/payslip.csv");
            _filepath = Console.ReadLine();
            
            var FileReader = new StreamReader(_filepath);
            List<string> csvData = new List<string>();
            
            string line = FileReader.ReadLine(); // Read headings line
            string[] values = line.Split(",");

            while (!FileReader.EndOfStream)
            {
                line = FileReader.ReadLine();
                csvData.Add(line);
            }

            List<EmployeeData> EmployeeList = new List<EmployeeData>();
            EmployeeData Employee;
            
            foreach (var item in csvData)
            {
                values = item.Split(","); 
                Employee = new EmployeeData();
                Employee.Name = values[0] + " " + values[1];
                Employee.AnnualSalary = Double.Parse(values[2]);
                //values[3] = values[3].Take(values[3].Length - 1).ToString();

                List<char> super = new List<char>(values[3]);
                super.RemoveAt(values[3].Length - 1);
                //values[3] = super.ToArray();
                //Console.WriteLine(values[3]);
                
                
                //Employee.SuperRate = Double.Parse(super);
                Employee.PayPeriod = values[4] + " - " + values[5];
                
                EmployeeList.Add(Employee);
            }
            
            // var values = line.Split(",");
            Console.WriteLine("Here are your values...\n");
            foreach (var item in EmployeeList)
            {
                Console.WriteLine(item.Name);
            }


            // ------------------------------------------- //
            // CONSOLE IO FUNCTIONALITY
            /*
             

            // Read salary
            string salary;
            bool repeat = true;
            while (repeat)
            {
                try
                {
                    Console.Write("Please enter your annual salary: ");
                    salary = Console.ReadLine();
                    Employee.AnnualSalary = Double.Parse(salary);
                    repeat = false;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error in UI.ReadData(): Invalid casting to double");
                    repeat = true;
                }
            }
            
            */

            return EmployeeList[0];
        }

        public void PrintPayslip(Payslip Payslip)
        {
            string filepath = "/Users/Alex.Ruddell/Documents/payslipV2/payslip.csv";
            Console.WriteLine("\nYour CSV is being written to:\n" + String.Format(filepath));
            Console.WriteLine("\nWriting...");

            // Write to CSV
            var FileWriter = new StreamWriter(filepath);
            // Write initial line
            var titleLine = "name, pay period, gross income, income tax, net income, super";
            FileWriter.WriteLine(titleLine);
            FileWriter.Flush();
            // Write data line
            string dataLine = Payslip.Name + ", " + Payslip.PayPeriod + ", " + Payslip.MonthlyGrossIncome +
                              ", " + Payslip.MonthlyTax + ", " + Payslip.MonthlyNetIncome + ", " + Payslip.MonthlySuper;
            FileWriter.WriteLine(dataLine);
            FileWriter.Flush();
            
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