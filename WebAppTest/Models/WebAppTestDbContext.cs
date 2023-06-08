using Microsoft.EntityFrameworkCore;

namespace WebAppTest.Models
{
    public class WebAppTestDbContext : DbContext
    {
        public WebAppTestDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Department> DepartmentSet { get; set; }  
        DbSet<Employee> EmployeeSet { get; set; }  
        DbSet<TimeSheet> TimeSheetSet { get; set; }
    }
}
