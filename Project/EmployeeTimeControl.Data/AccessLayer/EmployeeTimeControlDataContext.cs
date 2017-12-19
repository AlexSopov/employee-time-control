using EmployeeTimeControl.Data.Models;
using System.Data.Entity;

namespace EmployeeTimeControl.Data.AccessLayer
{
    public class EmployeeTimeControlDataContext : DbContext
    {
        public DbSet<Employee> EmployeeSet { get; set; }
    }
}
