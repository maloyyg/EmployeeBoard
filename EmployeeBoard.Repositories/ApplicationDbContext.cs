
using EmployeeBoard.DataModel;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBoard.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee>Employees { get; set; }
    }

}
