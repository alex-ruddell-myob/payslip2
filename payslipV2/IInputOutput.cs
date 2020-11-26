using System.Collections.Generic;

namespace payslipV2
{
    public interface IInputOutput
    {
        List<EmployeeData> ReadData();
        void PrintPayslip(List<Payslip> Payslips);
    }
}