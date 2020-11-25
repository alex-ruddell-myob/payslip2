using System;

namespace payslipV2
{
    class IO
    {
        public static Person Person = new Person();
        public static FinancialCalculator FinancialCalculator = new FinancialCalculator();

        public void ReadData()
        {
            // Read name
            Console.Write("Please input your first name: ");
            string nameFirst = Console.ReadLine();
            Console.Write("Please input your surname: ");
            string nameLast = Console.ReadLine();
            Person.Name = nameFirst + " " + nameLast;

            // Read salary
            string salary;
            bool repeat = true;
            while (repeat)
            {
                try
                {
                    Console.Write("Please enter your annual salary: ");
                    salary = Console.ReadLine();
                    Person.AnnualSalary = Double.Parse(salary);
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
            Person.SuperRate = Double.Parse(super);
            
            // Read pay period
            Console.Write("Please enter your payment start date: ");
            string dateStart = Console.ReadLine();
            Console.Write("Please enter your payment end date: ");
            string dateEnd = Console.ReadLine();
            Person.PayPeriod = dateStart + " - " + dateEnd;
        }

        public void ProcessData() // <<<
        {
            // Calculate monthly gross income
            Person.MonthlyGrossIncome = FinancialCalculator.CalculateMonthlyGrossIncome(Person.AnnualSalary);
            // Calculate monthly tax
            Person.MonthlyTax = FinancialCalculator.CalculateMonthlyTax(Person.AnnualSalary);
            // Calculate monthly net income
            Person.MonthlyNetIncome = FinancialCalculator.CalculateMonthlyNetIncome(Person.MonthlyGrossIncome, Person.MonthlyTax);
            // Calculate monthly super
            Person.MonthlySuper = FinancialCalculator.CalculateMonthlySuper(Person.AnnualSalary, Person.SuperRate);
        }

        public void PrintPayslip()
        {
            // Print payslip as per kata specification
            Console.WriteLine("\nYour payslip has been generated! \n");
            Console.WriteLine("Name: " + Person.Name);
            Console.WriteLine("Pay Period: " + Person.PayPeriod);
            Console.WriteLine("Gross Income: " + Person.MonthlyGrossIncome);
            Console.WriteLine("Income Tax: " + Person.MonthlyTax);
            Console.WriteLine("Net Income: " + Person.MonthlyNetIncome);
            Console.WriteLine("Super: " + Person.MonthlySuper);
            Console.WriteLine("\nThank you for using MYOB!");
        }

        public IO()
        {
            Console.WriteLine("Welcome to the payslip generator! Get ready for the most fun you've had ever!!!");
        }
    }
}