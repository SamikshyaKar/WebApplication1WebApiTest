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




    }
}
