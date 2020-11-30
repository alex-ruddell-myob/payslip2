using System;

namespace payslipV2
{
    public class FinancialCalculator
    {
        // Tax rates correspond to the salary brackets stated
        private readonly double[] _taxRate = new double[5] {0, 0.19, 0.325, 0.37, 0.45};
        private readonly double[] _salaryBracket = new double[5] {0, 18200, 37000, 87000, 180000};

        public Payslip GeneratePayslip(EmployeeData employee)
        {
            Payslip payslip = new Payslip
            {
                Name = employee.Name,
                PayPeriod = employee.PayPeriod,
                MonthlyGrossIncome = CalculateMonthlyGrossIncome(employee.AnnualSalary),
                MonthlyTax = CalculateMonthlyTax(employee.AnnualSalary)
            };

            payslip.MonthlyNetIncome = CalculateMonthlyNetIncome(payslip.MonthlyGrossIncome, payslip.MonthlyTax);
            payslip.MonthlySuper = CalculateMonthlySuper(employee.AnnualSalary, employee.SuperRate);

            return payslip;
        }
        
        public double CalculateMonthlyTax(double annualSalary)
        {
            double annualTax = 0.00;
            
            // Sums tax contributions based on salary tax brackets
            for (int i = _salaryBracket.Length - 1; i >= 0; i--)
            {
                if (annualSalary > _salaryBracket[i])
                {
                    annualTax += (annualSalary - _salaryBracket[i]) * _taxRate[i];
                    annualSalary = _salaryBracket[i];
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