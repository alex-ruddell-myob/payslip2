using System;
using System.Collections.Generic;
using System.IO;

namespace payslipV2
{
    public interface IInput
    {
        List<EmployeeData> ReadData();
    }
}