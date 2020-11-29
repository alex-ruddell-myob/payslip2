using System.Collections.Generic;

namespace payslipV2
{
    public interface IOutput
    {
        void PrintPayslip(List<Payslip> payslips);

        public static IOutput ConnectOutput(string arg)
        {
            if (arg == "Console")
            {
                return new ConsoleOutput();
            }
            else
            {
                return new CSVOutput(arg);
            }
        }
    }
}