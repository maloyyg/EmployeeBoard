using EmployeeBoard.Repositories.Implementation;
using EmployeeBoard.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace EmployeeBoard.Repositories
{
    public static class SetUpRepositories
    {
        public static void ConfigureRepositories(this IServiceCollection services,string dbConnectionString) 
        {
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(dbConnectionString));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        }

    }
}