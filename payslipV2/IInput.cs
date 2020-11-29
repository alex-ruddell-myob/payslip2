using System.Collections.Generic;

namespace payslipV2
{
    public interface IInput
    {
        List<EmployeeData> ReadData();

        public static IInput ConnectInput(string arg)
        {
            if (arg == "Console")
            {
                return new ConsoleInput();
            }
            else
            {
                return new CSVInput(arg);
            }
        }
    }
}