using System;

namespace payslipV2
{
    class ConsoleInputOutput : IInputOutput
    {
        public EmployeeData ReadData()
        {
            EmployeeData Employee = new EmployeeData();
            
            // Read name
            Console.Write("Please input your first name: ");
            string nameFirst = Console.ReadLine();
            Console.Write("Please input your surname: ");
            string nameLast = Console.ReadLine();
            Employee.Name = nameFirst + " " + nameLast;

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

            // Read super
            Console.Write("Please enter your super rate: ");
            string super = Console.ReadLine();
            Employee.SuperRate = Double.Parse(super);
            
            // Read pay period
            Console.Write("Please enter your payment start date: ");
            string dateStart = Console.ReadLine();
            Console.Write("Please enter your payment end date: ");
            string dateEnd = Console.ReadLine();
            Employee.PayPeriod = dateStart + " - " + dateEnd;

            return Employee;
        }

        public void PrintPayslip(Payslip Payslip)
        {
            // Print payslip as per kata specification
            Console.WriteLine("\nYour payslip has been generated! \n");
            Console.WriteLine("Name: " + Payslip.Name);
            Console.WriteLine("Pay Period: " + Payslip.PayPeriod);
            Console.WriteLine("Gross Income: " + Payslip.MonthlyGrossIncome);
            Console.WriteLine("Income Tax: " + Payslip.MonthlyTax);
            Console.WriteLine("Net Income: " + Payslip.MonthlyNetIncome);
            Console.WriteLine("Super: " + Payslip.MonthlySuper);
            Console.WriteLine("\nThank you for using MYOB!");
        }

        public ConsoleInputOutput()
        {
            Console.WriteLine("Welcome to the payslip generator! Get ready for the most fun you've had ever!!!");
        }

        /*
        ~ConsoleInputOutput()
        {
            Console.WriteLine("\nThank you for using MYOB!");
        }
        */
    }
}