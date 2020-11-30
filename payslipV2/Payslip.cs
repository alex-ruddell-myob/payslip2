using System;

namespace payslipV2
{
    public class Payslip
    {
        // Payslip variables
        private double monthlyGrossIncome;
        private double monthlyTax;
        private double monthlyNetIncome;
        private double monthlySuper;
        // Person variables
        private string name;
        private string payPeriod;
        
        public Payslip()
        {
            monthlyGrossIncome = 0.00;
            monthlyTax = 0.00;
            monthlyNetIncome = 0.00;
            monthlySuper = 0.00;
        }
        
        // Getters & Setters
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
        
        public string Name
        {
            get => name;
            set => name = value;
        }

        public string PayPeriod
        {
            get => payPeriod;
            set => payPeriod = value;
        }
        
    }
}