using System;
using System.Collections.Generic;
using System.IO;

namespace payslipV2
{
    class CSVHandler
    {
        public string FormatPayslip(Payslip Payslip)
        {
            return Payslip.Name + "," + Payslip.PayPeriod + "," + Payslip.MonthlyGrossIncome +
                              "," + Payslip.MonthlyTax + "," + Payslip.MonthlyNetIncome + "," + Payslip.MonthlySuper;
        }
        public EmployeeData ConvertToEmployee(string row)
        {
            EmployeeData Employee = new EmployeeData();
            
            string[] values = row.Split(","); 
            Employee = new EmployeeData();
            Employee.Name = values[0] + " " + values[1];
            Employee.AnnualSalary = Double.Parse(values[2]);
            Employee.SuperRate = Double.Parse(values[3].TrimEnd('%'));
            Employee.PayPeriod = values[4] + " - " + values[5];

            return Employee;
        }
        public List<string> GetData(string readpath)
        {
            List<string> data = new List<string>();
            
            var FileReader = new StreamReader(readpath);
            string line = FileReader.ReadLine(); // Read headings line

            while (!FileReader.EndOfStream)
            {
                line = FileReader.ReadLine();
                data.Add(line);
            }
            
            return data;
        }
    }
}