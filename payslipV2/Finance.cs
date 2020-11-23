using System;

namespace payslipV2
{
    class Finance
    {
        // Tax rates correspond to the salary brackets stated
        private double[] taxRate = new double[5] {0, 0.19, 0.325, 0.37, 0.45};
        private double[] salaryBracket = new double[5] {0, 18200, 37000, 87000, 180000};
        
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
        
        public double CalculateMonthlyTax(double annualSalary)
        {
            double salary = annualSalary;
            double annualTax = 0.00;

            for (int i = 4; i >= 0; i--)
            {
                if (annualSalary > salaryBracket[i])
                {
                    annualTax += (salary - salaryBracket[i]) * taxRate[i];
                    salary -= (annualSalary - salaryBracket[i]);
                }
            }

            double monthlyTax = Math.Ceiling(annualTax / 12);
            return monthlyTax;
        }
    }
}