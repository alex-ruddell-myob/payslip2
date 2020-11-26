using System;

namespace payslipV2
{
    public class FinancialCalculator
    {
        // Tax rates correspond to the salary brackets stated
        private double[] taxRate = new double[5] {0, 0.19, 0.325, 0.37, 0.45};
        private double[] salaryBracket = new double[5] {0, 18200, 37000, 87000, 180000};

        public Payslip GeneratePayslip(EmployeeData Employee)
        {
            Payslip Payslip = new Payslip();

            Payslip.Name = Employee.Name;
            Payslip.PayPeriod = Employee.PayPeriod;
            Payslip.MonthlyGrossIncome = CalculateMonthlyGrossIncome(Employee.AnnualSalary);
            Payslip.MonthlyTax = CalculateMonthlyTax(Employee.AnnualSalary);
            Payslip.MonthlyNetIncome = CalculateMonthlyNetIncome(Payslip.MonthlyGrossIncome, Payslip.MonthlyTax);
            Payslip.MonthlySuper = CalculateMonthlySuper(Employee.AnnualSalary, Employee.SuperRate);

            return Payslip;
        }
        
        public double CalculateMonthlyTax(double annualSalary)
        {
            double annualTax = 0.00;
            
            // Sums tax contributions based on salary tax brackets
            for (int i = salaryBracket.Length - 1; i >= 0; i--)
            {
                if (annualSalary > salaryBracket[i])
                {
                    annualTax += (annualSalary - salaryBracket[i]) * taxRate[i];
                    annualSalary = salaryBracket[i];
                }
            }

            double monthlyTax = Math.Round(annualTax / 12);
            return monthlyTax;
        }

        public double CalculateMonthlyGrossIncome(double annualSalary)
        {
            return Math.Floor(annualSalary / 12);
        }

        public double CalculateMonthlyNetIncome(double monthlySalary, double monthlyTax)
        {
            return monthlySalary - monthlyTax;
        }

        public double CalculateMonthlySuper(double annualSalary, double superRate)
        {
            double annualSuper = Math.Floor(annualSalary * (superRate / 100));
            double monthlySuper = annualSuper / 12;
            return Math.Floor(monthlySuper);
        }
    }
}