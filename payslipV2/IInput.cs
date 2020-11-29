using System.Collections.Generic;

namespace payslipV2
{
    public interface IInput
    {
        List<EmployeeData> ReadData();
    }
}