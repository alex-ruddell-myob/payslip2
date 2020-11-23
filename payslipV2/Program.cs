using System;

namespace payslipV2
{
    class Program
    {
        public static UI Interface = new UI();
        
        static void Main(string[] args)
        {
            // Read Data
            Interface.ReadData();
            
            // Process Data
            Interface.ProcessData();
            
            // Print data
            Interface.PrintPayslip();
        }
    }
}