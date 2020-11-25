using System;

namespace payslipV2
{
    class Program
    {
        public static IO SystemIO = new IO();
        
        static void Main(string[] args)
        {
            // New structure...
            // Person = SystemIO Read Data and assign it to a person
            // Payslip = GeneratePayslip(Person)
            // Message Out = Payslip.Print


            // Read Data
            SystemIO.ReadData(); // <<<
            
            // Process Data
            SystemIO.ProcessData();
            
            // Print data
            SystemIO.PrintPayslip();
        }
    }
}