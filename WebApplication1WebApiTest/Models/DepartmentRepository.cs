using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1WebApiTest.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
     
        private readonly AppDbContext appdbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appdbContext = appDbContext;
        }
        public  async Task<Department> GetDepartmentbyID(int DepartmentID)
        {
            var result = await appdbContext.departmentsprop.FirstOrDefaultAsync(e => e.DepartmentID == DepartmentID);
            return result;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            var result = await appdbContext.departmentsprop.ToListAsync();
            return result;

        }
    }
}
