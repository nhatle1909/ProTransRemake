using Application.Interface.IService;
using Application.Service;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IDistanceService, DistanceService>();
            services.AddScoped<ITransactionService, TransactionService>();
            //services.AddSingleton(TypeAdapterConfig.GlobalSettings);
            //services.AddScoped<ITypeAdapter>(sp => sp.GetRequiredService<TypeAdapterConfig>());
        }
    }
}
