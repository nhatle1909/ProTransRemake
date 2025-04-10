using Application.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureService(this IServiceCollection services,string connectionString)
        {
         
            services.AddDbContext<ProTransDbContext>(options =>options.UseSqlServer(connectionString));
            //Unitofwork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //GenericRepository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddMemoryCache();
        }
    }
}
