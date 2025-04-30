using Application.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureService(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<ProTransDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            //Unitofwork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //GenericRepository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ISendMailOTPRepository, SendMailOTPRepository>();
            services.AddMemoryCache();
        }
    }
}
