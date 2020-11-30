using System;
using System.Collections.Generic;

namespace payslipV2
{
    class ConsoleInput : IInput
    {
        public List<EmployeeData> ReadData()
        {
            bool run = true;
            
            var employeeList = new List<EmployeeData>();

            while (run)
            {
                var employee = new EmployeeData();

                // Read name
                Console.Write("\nPlease input your first name: ");
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
                repeat = true;
                while (repeat)
                {
                    try
                    {
                        Console.Write("Please enter your super rate: ");
                        var super = Console.ReadLine();
                        employee.SuperRate = Double.Parse(super);
                        repeat = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid superannuation amount entered. Please enter a numerical value.");
                        repeat = true;
                    }
                }
                
                // Read pay period
                Console.Write("Please enter your payment start date: ");
                var dateStart = Console.ReadLine();
                Console.Write("Please enter your payment end date: ");
                var dateEnd = Console.ReadLine();
                employee.PayPeriod = dateStart + " - " + dateEnd;
            
                employeeList.Add(employee);

                bool loop = true;

                while (loop)
                {
                    Console.Write("\nWould you like to enter another employee? (Y/N):  ");
                    var answer = Console.ReadLine();

                    switch (answer)
                    {
                        case "N":
                            run = false;
                            loop = false;
                            break;
                        case "Y":
                            loop = false;
                            break;
                    }
                }
            }
            
            return employeeList;
        }
        
        public ConsoleInput()
        {
            Console.WriteLine("Welcome to the payslip generator!");
        }
    }
}