using System;
using System.Collections.Generic;
using System.IO;

namespace payslipV2
{
    class CSVHandler
    {
        public static string FormatPayslip(Payslip payslip)
        {
            return payslip.Name + "," + payslip.PayPeriod + "," + payslip.MonthlyGrossIncome +
                              "," + payslip.MonthlyTax + "," + payslip.MonthlyNetIncome + "," + payslip.MonthlySuper;
        }
        public static EmployeeData ConvertToEmployee(string row)
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
        public static List<string> GetData(string readpath)
        {
            List<string> data = new List<string>();
            
            var fileReader = new StreamReader(readpath);
            string line = fileReader.ReadLine(); // Read headings line

            while (!fileReader.EndOfStream)
            {
                line = fileReader.ReadLine();
                data.Add(line);
            }
            
            return data;
        }
    }
}