using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1WebApiTest.Models;

namespace WebApplication1WebApiTest.Controllers
{

   

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController:ControllerBase

    {
        private readonly IEmployeerepository employeerepository;

        public EmployeeController(IEmployeerepository iemployeeRepository)
        {
            this.employeerepository = iemployeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await employeerepository.GetEmployees());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"error rzetrieving data from database");
            }
            
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployeebyID(int ID)
        {
            try
            {
                var result= (await employeerepository.GetEmployeebyID(ID));

                if (result == null)
                {
                    return NotFound();
                }

                return result;

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving data from database");

            }

        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if(employee==null)
                {
                    return BadRequest();
                }
                var emp = await employeerepository.GetEmployeebyEmail(employee.Email);
                if (emp != null)
                {
                    ModelState.AddModelError("Email", "Employee Email already in Use");
                    return BadRequest(ModelState);
                }

                var CreateEmp = await employeerepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployeebyID), new { id = CreateEmp.EmployeeId }, CreateEmp);

              

            }
            catch (Exception )
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"Error in Creating new Employee");
            }


        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee (int id, Employee employee)
        {
            try
            {
                if(id != employee.EmployeeId)
                {
                    return BadRequest("Employee ID Mismatch");
                }

                var EmployeetobeUpdated = await employeerepository.GetEmployeebyID(id);

                if (EmployeetobeUpdated== null)
                {
                    return NotFound($" Employee with ID = {id} Not Found");
                }

                var EmployeeUpdated = await employeerepository.UpdateEmployee(employee);

                return EmployeeUpdated;
            }

            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Updating Employee");

            }


        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> DeleteEmployee(int id )
        {
            try
            {
                var EmptobeDeleted = await employeerepository.GetEmployeebyID(id);

                if(EmptobeDeleted == null)
                {
                    return NotFound($" Employee with ID= {id} NOT Found");
                }

                 await employeerepository.DeleteEmployee(id);
                  return Ok($"Employee with ID= {id} is DELETED");

            }

            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Deleting Employee");

            }

        }

        [HttpGet("{Search}")]

        public async Task<ActionResult<IEnumerable<Employee>>> Search (String Name, Gender ? gender)
        {

            try
            {
                var result = await employeerepository.SearchEmployee(Name, gender);
                if ( result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }

            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Employee Not Found");
            }
        }


    }
}
