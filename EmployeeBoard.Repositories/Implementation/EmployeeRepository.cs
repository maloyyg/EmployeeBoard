using EmployeeBoard.DataModel;
using EmployeeBoard.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBoard.Repositories.Implementation
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public List<Employee> GetEmployees()
        { 
            return _dbContext.Employees.ToList();
        }

        public Employee GetEmployee(Guid id) 
        {
            return _dbContext.Employees.FirstOrDefault(a => a.Id == id);
        }

        public bool AddEmployee(Employee employee) 
        {
            _dbContext.Employees.Add(employee);
            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteEmployee(Guid id) 
        {
            var employee = _dbContext.Employees.FirstOrDefault(a => a.Id == id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                return _dbContext.SaveChanges() > 0;
            }
            else 
            {
                return false;
            }
        }


        public bool UpdateEmployee(Employee employee) 
        {
            _dbContext.Employees.Update(employee);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
