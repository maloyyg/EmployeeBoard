using AutoMapper;
using EmployeeBoard.DataModel;
using EmployeeBoard.DTO;
using EmployeeBoard.Repositories.Interface;
using EmployeeBoard.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBoard.Services.Implementation
{
    public class EmployeeServices :IEmployeeServices
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeServices> _logger;
        private readonly IMapper _mapper;

        public EmployeeServices(IEmployeeRepository employeeRepository,IMapper mapper,ILogger<EmployeeServices> logger) 
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public List<EmployeeDTO> GetEmployees()
        {
            _logger.LogInformation("Getting all employees");
            return _mapper.Map<List<EmployeeDTO>>( _employeeRepository.GetEmployees());
        }


        public EmployeeDTO GetEmployee(Guid id)
        {
            _logger.LogInformation($"Getting employee with id {id}");
            return _mapper.Map<EmployeeDTO>(_employeeRepository.GetEmployee(id));
        }
        public bool AddEmployee(AddEmployeeDTO employee)
        {
            _logger.LogInformation($"Adding employee with name {employee?.Name}");
            Employee emp = _mapper.Map<Employee>( employee);
            return _employeeRepository.AddEmployee(emp);
        }
        public bool DeleteEmployee(Guid id)
        {
            _logger.LogInformation($"Deleting employee with id {id}");
            return _employeeRepository.DeleteEmployee(id);
        }
        public bool UpdateEmployee(UpdateEmployeeDTO employee,Guid id)
        {
            _logger.LogInformation($"Updating employee with id {id}");
            Employee emp = _employeeRepository.GetEmployee(id);
            Employee updatedEmployee = _mapper.Map<UpdateEmployeeDTO, Employee>(employee,emp);
            return _employeeRepository.UpdateEmployee(updatedEmployee);
        }



    }
}
