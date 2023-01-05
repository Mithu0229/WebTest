using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebTest.Models;
using WebTest.Paging;
using WebTest.Repository;

namespace WebTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;
       
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //all employees
        
        [HttpGet]
       // [Authorize(Policy = "UserPolicy")]
        public async Task<ActionResult<IEnumerable<Employee>>>GetEmployees([FromQuery] PagingParameters pagingParameters)
        {

            return await _employeeRepository.GetEmployees(pagingParameters);
        }

        //employee by id
        
        [HttpGet("{id}")]
        //[Authorize(Policy = "UserPolicy")]
        public ActionResult<Employee>GetEmployeeById(int id)
        {
            var emp = _employeeRepository.GetEmployeeById(id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(emp);
            }
        }


        [HttpPost]
       // [Authorize(Policy = "UserPolicy")]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
        {
            if(employee == null)
            {
                return BadRequest("Employee object is null");

            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            _employeeRepository.CreateEmployee(employee);
            return Ok(CreatedAtRoute("Id", new { id = employee.Id }, employee));
        }

        [HttpPut("{id}")]
        //[Authorize(Policy = "UserPolicy")]
        public ActionResult<Employee> UpdateEmployee(int id,[FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee object is null");

            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var dbEmp = _employeeRepository.GetEmployeeById(id);
            if (!dbEmp.Id.Equals(id))
            {
                return NotFound();
            }
            _employeeRepository.UpdateEmployee(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
       // [Authorize(Policy = "UserPolicy")]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            
            var dbEmp = _employeeRepository.GetEmployeeById(id);
            if (!dbEmp.Id.Equals(id))
            {
                return NotFound();
            }
            _employeeRepository.DeleteEmployee(dbEmp);
            return NoContent();
        }
    }
}
