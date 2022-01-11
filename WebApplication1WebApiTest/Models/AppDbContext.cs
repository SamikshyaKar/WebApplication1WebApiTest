using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1WebApiTest.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    
        {



        }

        public DbSet<Employee> Employeeprop { get; set; }
        public DbSet<Department> departmentsprop { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department {  DepartmentID=1, DepartmentName="IT"});

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID = 2, DepartmentName = "HR" });

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID = 3, DepartmentName = "PayRoll" });

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID = 4, DepartmentName = "Staffing" });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId=101,
                FirstName="Sara",
                LastName="Tondon",
                Email="sara@gmail.com",
                Gender=Gender.Female,
                DepartmentId=1,
                PhotoPath="~/wwwroot/Images/Flower1.jpg",
                DateOfBrith=new DateTime(2000,9,23)
            });


            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 102,
                FirstName = "John",
                LastName = "Srikant",
                Email = "John@gmail.com",
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "~/wwwroot/Images/Flower2.jpg",
                DateOfBrith = new DateTime(2001, 9, 23)
            });
        }
    }

    
}
