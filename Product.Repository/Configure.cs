using Product.Repository.Interface;
using Product.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Product.Repository
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            DAL.Configure.ConfigureServices(services, connectionString);
            //Authenticate Repository and Token options as dependency injection
            services.AddScoped<IAct, ActRepository>();
            services.AddScoped<IEmployee, EmployeeRepository>();
        }
    }
}
