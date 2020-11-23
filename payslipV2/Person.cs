using System;
using System.Runtime.CompilerServices;

namespace payslipV2
{
    class Person
    {
        // Input variables
        private string name;
        private double annualSalary;
        private double superRate;
        private string payPeriod;
        // Calculated variables
        private double monthlyGrossIncome;
        private double monthlyTax;
        private double monthlyNetIncome;
        private double monthlySuper;
        
        // Getters & Setters
        public string Name
        {
            get => name;
            set => name = value;
        }

        public double AnnualSalary
        {
            get => annualSalary;
            set => annualSalary = value;
        }

        public double SuperRate
        {
            get => superRate;
            set => superRate = value;
        }

        public string PayPeriod
        {
            get => payPeriod;
            set => payPeriod = value;
        }

        public double MonthlyGrossIncome
        {
            get => monthlyGrossIncome;
            set => monthlyGrossIncome = value;
        }

        public double MonthlyTax
        {
            get => monthlyTax;
            set => monthlyTax = value;
        }

        public double MonthlyNetIncome
        {
            get => monthlyNetIncome;
            set => monthlyNetIncome = value;
        }

        public double MonthlySuper
        {
            get => monthlySuper;
            set => monthlySuper = value;
        }

        // Initialisation Constructor
        public Person()
        {
            this.name = "";
            this.annualSalary = 0.00;
            this.superRate = 0.00;
            this.payPeriod = "";
            this.monthlyGrossIncome = 0.00;
            this.monthlyTax = 0.00;
            this.monthlyNetIncome = 0.00;
            this.monthlySuper = 0.00;
        }
    }
}