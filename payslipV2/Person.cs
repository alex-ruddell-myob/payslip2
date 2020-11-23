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

        // Setters
        public void SetName(string nameFirst, string nameLast)
        {
            this.name = nameFirst + " " + nameLast;
        }

        public void SetAnnualSalary(double input)
        {
            this.annualSalary = input;
        }

        public void SetSuperRate(double input)
        {
            this.superRate = input;
        }

        public void SetPayPeriod(string dateStart, string dateEnd)
        {
            this.payPeriod = dateStart + " - " + dateEnd;
        }

        public void SetMonthlyGrossIncome(double input)
        {
            this.monthlyGrossIncome = input;
        }

        public void SetMonthlyTax(double input)
        {
            this.monthlyTax = input;
        }

        public void SetMonthlyNetIncome(double input)
        {
            this.monthlyNetIncome = input;
        }

        public void SetMonthlySuper(double input)
        {
            this.monthlySuper = input;
        }

        // Getters
        public string GetName()
        {
            return this.name;
        }
        
        public double GetAnnualSalary()
        {
            return this.annualSalary;
        }
        
        public double GetSuperRate()
        {
            return this.superRate;
        }
        
        public string GetPayPeriod()
        {
            return this.payPeriod;
        }

        public double GetMonthlyGrossIncome()
        {
            return this.monthlyGrossIncome;
        }

        public double GetMonthlyTax()
        {
            return this.monthlyTax;
        }
        
        public double GetMonthlyNetIncome()
        {
            return this.monthlyNetIncome;
        }

        public double GetMonthlySuper()
        {
            return this.monthlySuper;
        }
    }
}