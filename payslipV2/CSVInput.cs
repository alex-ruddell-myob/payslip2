using System;
using System.Collections.Generic;
using System.IO;

namespace payslipV2
{
    class CSVInput : IInput
    {
        private readonly string _readPath;

        public List<EmployeeData> ReadData()
        {
            var employeeList = new List<EmployeeData>();
            
            List<string> csvData = CSVHandler.GetData(_readPath);
            
            foreach (var row in csvData)
            {
                var employee = CSVHandler.ConvertToEmployee(row);
                employeeList.Add(employee);
            }

            return employeeList;
        }

        public CSVInput(string arg)
        {
            _readPath = arg;
        }
    }
}