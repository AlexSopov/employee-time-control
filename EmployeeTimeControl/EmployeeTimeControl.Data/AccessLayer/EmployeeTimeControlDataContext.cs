using EmployeeTimeControl.Data.Models;
using System.Data.Entity;

namespace EmployeeTimeControl.Data
{
    public class EmployeeTimeControlDataContext : DbContext
    {
        public DbSet<Employee> EmployeeSet { get; set; }
    }
}
