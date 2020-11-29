using System.Collections.Generic;

namespace payslipV2
{
    public interface IOutput
    {
        void PrintPayslip(List<Payslip> payslips);
    }
}