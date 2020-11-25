using System;
using System.IO;

namespace payslipV2
{
    class CSVInputOutput : IInputOutput
    {
        public EmployeeData ReadData()
        {
            // READ CSV ?? Implement this later.
            
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
            string filepath = @"/Users/Alex.Ruddell/Documents/payslipV2/payslip.csv";
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