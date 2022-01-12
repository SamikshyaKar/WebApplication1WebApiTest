using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1WebApiTest.Models
{
    public class EmployeeRepository : IEmployeerepository
    {
        private readonly AppDbContext appDBContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDBContext = appDbContext;
        }
        public  async Task<Employee> AddEmployee(Employee employee)
        {
            if(employee.Department !=null)
            {
                appDBContext.Entry(employee.Department).State = EntityState.Unchanged;
            }
            var result = await appDBContext.Employeeprop.AddAsync(employee);
            await  appDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public  async Task DeleteEmployee(int empID)
        {
            var result = await appDBContext.Employeeprop.FirstOrDefaultAsync(e => e.EmployeeId == empID);

            if(result !=null)
            {
                appDBContext.Employeeprop.Remove(result);
                await appDBContext.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetEmployeebyEmail(string employeeEmail)
        {
            var result = await appDBContext.Employeeprop.FirstOrDefaultAsync(e => e.Email == employeeEmail);
            return result;
        }

        public  async Task<Employee> GetEmployeebyID(int employeeID)
        {
            var result = await appDBContext.Employeeprop.Include(e => e.Department).FirstOrDefaultAsync
                (e => e.EmployeeId == employeeID);
            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var result = await appDBContext.Employeeprop.ToListAsync();
            return result;
        }

        public  async Task<IEnumerable<Employee>> SearchEmployee(string name, Gender? gender)
        {
            IQueryable<Employee> query = appDBContext.Employeeprop;
            if(!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));

            }
            if(gender !=null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }

        public  async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await appDBContext.Employeeprop.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);

            if (result !=null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.Gender = employee.Gender;
                result.PhotoPath = result.PhotoPath;
                result.DateOfBrith = result.DateOfBrith;
                result.DepartmentId = result.DepartmentId;

                await appDBContext.SaveChangesAsync();
                return result;
            }

            return null;

        }
    }
}
