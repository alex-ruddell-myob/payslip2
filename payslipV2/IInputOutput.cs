namespace payslipV2
{
    public interface IInputOutput
    {
        EmployeeData ReadData();
        void PrintPayslip(Payslip Payslip);
    }
}