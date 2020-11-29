using System;
using System.Collections.Generic;

namespace payslipV2
{
    class ConsoleInputOutput : IInputOutput
    {
        public List<EmployeeData> ReadData()
        {
            var employee = new EmployeeData();
            
            // TODO(Alex): Could write some multiple-console-input functionality in order to List better
            //             >> Currently it is just used as the interface requires a list be returned
            //             >> Allow the user to input multiple employees?
            var employeeList = new List<EmployeeData>();
            
            // Read name
            Console.Write("Please input your first name: ");
            var nameFirst = Console.ReadLine();
            Console.Write("Please input your surname: ");
            var nameLast = Console.ReadLine();
            employee.Name = nameFirst + " " + nameLast;

            // Read salary
            var repeat = true;
            while (repeat)
            {
                try
                {
                    Console.Write("Please enter your annual salary: ");
                    var salary = Console.ReadLine();
                    employee.AnnualSalary = double.Parse(salary);
                    repeat = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid salary entered. Please enter a numerical value.");
                    repeat = true;
                }
            }

            // Read super
            Console.Write("Please enter your super rate: ");
            var super = Console.ReadLine();
            employee.SuperRate = Double.Parse(super);
            
            // Read pay period
            Console.Write("Please enter your payment start date: ");
            var dateStart = Console.ReadLine();
            Console.Write("Please enter your payment end date: ");
            var dateEnd = Console.ReadLine();
            employee.PayPeriod = dateStart + " - " + dateEnd;
            
            employeeList.Add(employee);
            
            return employeeList;
        }

        public void PrintPayslip(List<Payslip> payslips)
        {
            // Print payslip as per kata specification
            foreach (var payslip in payslips)
            {
                Console.WriteLine("\nYour payslip has been generated! \n");
                Console.WriteLine("Name: " + payslip.Name);
                Console.WriteLine("Pay Period: " + payslip.PayPeriod);
                Console.WriteLine("Gross Income: " + payslip.MonthlyGrossIncome);
                Console.WriteLine("Income Tax: " + payslip.MonthlyTax);
                Console.WriteLine("Net Income: " + payslip.MonthlyNetIncome);
                Console.WriteLine("Super: " + payslip.MonthlySuper);
            }
            
            Console.WriteLine("\nThank you for using MYOB!");
        }

        public ConsoleInputOutput()
        {
            Console.WriteLine("Welcome to the payslip generator!");
        }
    }
}