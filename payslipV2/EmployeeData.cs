using System;
using System.Runtime.CompilerServices;

namespace payslipV2
{
    public class EmployeeData
    {
        // Input variables
        private string name;
        private double annualSalary;
        private double superRate;
        private string payPeriod;
        
        // Initialisation Constructor
        public EmployeeData()
        {
            this.name = "";
            this.annualSalary = 0.00;
            this.superRate = 0.00;
            this.payPeriod = "";
        }

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
    }
}