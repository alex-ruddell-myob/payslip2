using System;

namespace payslipV2
{
    class UI
    {
        public static Person Person1 = new Person();
        public static Finance Finance1 = new Finance();

        public void ReadData()
        {
            Console.Write("Please input your first name: ");
            string nameFirst = Console.ReadLine();
            Console.Write("Please input your surname: ");
            string nameLast = Console.ReadLine();
            Person1.SetName(nameFirst, nameLast);

            Console.Write("Please enter your annual salary: ");
            string salary = Console.ReadLine();
            Person1.SetAnnualSalary(Double.Parse(salary));
            
            Console.Write("Please enter your super rate: ");
            string super = Console.ReadLine();
            Person1.SetSuperRate(Double.Parse(super));
            
            Console.Write("Please enter your payment start date: ");
            string dateStart = Console.ReadLine();
            Console.Write("Please enter your payment end date: ");
            string dateEnd = Console.ReadLine();
            Person1.SetPayPeriod(dateStart, dateEnd);
        }

        public void ProcessData()
        {
            Person1.SetMonthlyGrossIncome(Finance1.CalculateMonthlyGrossIncome(Person1.GetAnnualSalary()));
            Person1.SetMonthlyTax(Finance1.CalculateMonthlyTax(Person1.GetAnnualSalary()));
            Person1.SetMonthlyNetIncome(Finance1.CalculateMonthlyNetIncome(Person1.GetMonthlyGrossIncome(), Person1.GetMonthlyTax()));
            Person1.SetMonthlySuper(Finance1.CalculateMonthlySuper(Person1.GetAnnualSalary(), Person1.GetSuperRate()));
        }

        public void PrintPayslip()
        {
            Console.WriteLine("\nYour payslip has been generated! \n");
            Console.WriteLine("Name: " + Person1.GetName());
            Console.WriteLine("Pay Period: " + Person1.GetPayPeriod());
            Console.WriteLine("Gross Income: " + Person1.GetMonthlyGrossIncome());
            Console.WriteLine("Income Tax: " + Person1.GetMonthlyTax());
            Console.WriteLine("Net Income: " + Person1.GetMonthlyNetIncome());
            Console.WriteLine("Super: " + Person1.GetMonthlySuper());
            Console.WriteLine("\nThank you for using MYOB!");
        }

        public UI()
        {
            Console.WriteLine("Welcome to the payslip generator! Get ready for the most fun you've had ever!!!");
        }
    }
}