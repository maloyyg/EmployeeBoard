using EmployeeBoard.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBoard.Repositories.Interface
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(Guid id);
        bool AddEmployee(Employee employee);
        bool DeleteEmployee(Guid id);
        bool UpdateEmployee(Employee employee);
    }
}
