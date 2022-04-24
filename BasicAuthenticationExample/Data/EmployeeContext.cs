using BasicAuthenticationExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicAuthenticationExample.Data
{
    public class EmployeeContext:DbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Employee> Employees { get; set;}
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)   
        {

        }
    }
}
