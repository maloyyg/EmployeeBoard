using EmployeeBoard.DataModel;
using EmployeeBoard.DTO;


namespace EmployeeBoard.Services.Interface
{
    public interface IEmployeeServices
    {
        List<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployee(Guid id);
        bool AddEmployee(AddEmployeeDTO employee);
        bool DeleteEmployee(Guid id);
        bool UpdateEmployee(UpdateEmployeeDTO employee, Guid id);
    }
}
