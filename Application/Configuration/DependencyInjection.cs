using Application.Interface.IService;
using Application.Service;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configuration
{
    public static class DependencyInjection
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<ITranslationPriceService, TranslationPriceService>();
            services.AddScoped<ITranslationSkillService, TranslationSkillService>();
            services.AddScoped<IAgencyService, AgencyService>();
            services.AddScoped<IAuthService, UserAuthService>();

            //services.AddSingleton(TypeAdapterConfig.GlobalSettings);
            //services.AddScoped<ITypeAdapter>(sp => sp.GetRequiredService<TypeAdapterConfig>());
        }
    }
}
