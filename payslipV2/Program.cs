using System;

namespace payslipV2
{
    class Program
    {
        public static UI UI = new UI();
        
        static void Main(string[] args)
        {
            // Read Data
            UI.ReadData(); // <<<
            
            // Process Data
            UI.ProcessData();
            
            // Print data
            UI.PrintPayslip();
        }
    }
}