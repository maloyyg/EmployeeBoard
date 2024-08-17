using EmployeeBoard.DTO;
using EmployeeBoard.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBoard.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeesController( IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeServices.GetEmployees());

        }

        [HttpGet]
        [Route("(id:guid")]

        public IActionResult GetEmploeeeById(Guid id)
        {
            var employee=_employeeServices.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDTO addEmployeeDTO)
        {
            bool isSuccess = _employeeServices.AddEmployee(addEmployeeDTO);
            if (isSuccess)
            {
                return Ok(new { message = "Employee successfully created" });
            }
            else
            { 
                return BadRequest(new { message = "Error occured during employee creation" });
            }

        }


        [HttpPut]
        [Route("(id:guid")]

        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDTO updateEmployeeDTO)
        {
            bool isSuccess = _employeeServices.UpdateEmployee(updateEmployeeDTO,id);
            if (isSuccess)
            {
                return Ok(new { message = "Employee successfully updated" });
            }
            else
            {
                return BadRequest(new { message = "Error occured during employee updation" });
            }
        }

        [HttpDelete]
        [Route("(id:guid")]

        public IActionResult DeleteEmployee(Guid id)
        {
            bool isSuccess = _employeeServices.DeleteEmployee(id);
            if (isSuccess)
            {
                return Ok(new { message = "Employee successfully deleted" });
            }
            else
            {
                return BadRequest(new { message = "Error occured during employee deletion" });
            }
        }

    }
}
