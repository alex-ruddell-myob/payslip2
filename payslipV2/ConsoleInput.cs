using System;
using System.Collections.Generic;

namespace payslipV2
{
    class ConsoleInput : IInput
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
        
        public ConsoleInput()
        {
            Console.WriteLine("Welcome to the payslip generator!");
        }
    }
}