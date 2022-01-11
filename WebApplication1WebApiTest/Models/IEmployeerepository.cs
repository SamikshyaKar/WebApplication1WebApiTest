using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1WebApiTest.Models
{
    public interface IEmployeerepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<IEnumerable<Employee>> SearchEmployee(string name, Gender? gender);

        Task<Employee> GetEmployeebyID(int employeeID);
        Task<Employee> GetEmployeebyEmail(string employeeEmail);

        Task<Employee> UpdateEmployee(Employee employee);

        Task<Employee> AddEmployee(Employee employee);
        Task DeleteEmployee(int empID);





    }
}
