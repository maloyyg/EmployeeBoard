using EmployeeBoard.Services.Implementation;
using EmployeeBoard.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeBoard.Services
{
    public static class SetUpServices
    {
        public static void ConfigureServices(this IServiceCollection services) 
        {
            services.AddSingleton(MapperConfig.InitializeAutomapper());
            services.AddScoped<IEmployeeServices, EmployeeServices>();
        }

    }
}