using Microsoft.EntityFrameworkCore;

namespace WebAppTest.Models
{
    public class WebAppTestDbContext : DbContext
    {
        public WebAppTestDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Department> DepartmentSet { get; set; }
        public DbSet<Employee> EmployeeSet { get; set; }
       public DbSet<TimeSheet> TimeSheetSet { get; set; }
    }
}
