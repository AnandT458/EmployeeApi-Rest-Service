﻿using EmployeeAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options):base(options)
        {

        }
      
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }

    
}
