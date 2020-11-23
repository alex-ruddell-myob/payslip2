using System;

namespace payslipV2
{
    class UI
    {
        public static Person Person1 = new Person();
        public static Finance Finance1 = new Finance();

        public void ReadData()
        {
            // Read name
            Console.Write("Please input your first name: ");
            string nameFirst = Console.ReadLine();
            Console.Write("Please input your surname: ");
            string nameLast = Console.ReadLine();
            Person1.Name = nameFirst + " " + nameLast;
            Console.WriteLine(Person1.Name);

            // Read salary
            Console.Write("Please enter your annual salary: ");
            string salary = Console.ReadLine();
            Person1.AnnualSalary = Double.Parse(salary);

            // Read super
            Console.Write("Please enter your super rate: ");
            string super = Console.ReadLine();
            Person1.SuperRate = Double.Parse(super);
            
            // Read pay period
            Console.Write("Please enter your payment start date: ");
            string dateStart = Console.ReadLine();
            Console.Write("Please enter your payment end date: ");
            string dateEnd = Console.ReadLine();
            Person1.PayPeriod = dateStart + " - " + dateEnd;
        }

        public void ProcessData()
        {
            Person1.MonthlyGrossIncome = Finance1.CalculateMonthlyGrossIncome(Person1.AnnualSalary);
            Person1.MonthlyTax = Finance1.CalculateMonthlyTax(Person1.AnnualSalary);
            Person1.MonthlyNetIncome = Finance1.CalculateMonthlyNetIncome(Person1.MonthlyGrossIncome, Person1.MonthlyTax);
            Person1.MonthlySuper = Finance1.CalculateMonthlySuper(Person1.AnnualSalary, Person1.SuperRate);
        }

        public void PrintPayslip()
        {
            Console.WriteLine("\nYour payslip has been generated! \n");
            Console.WriteLine("Name: " + Person1.Name);
            Console.WriteLine("Pay Period: " + Person1.PayPeriod);
            Console.WriteLine("Gross Income: " + Person1.MonthlyGrossIncome);
            Console.WriteLine("Income Tax: " + Person1.MonthlyTax);
            Console.WriteLine("Net Income: " + Person1.MonthlyNetIncome);
            Console.WriteLine("Super: " + Person1.MonthlySuper);
            Console.WriteLine("\nThank you for using MYOB!");
        }

        public UI()
        {
            Console.WriteLine("Welcome to the payslip generator! Get ready for the most fun you've had ever!!!");
        }
    }
}