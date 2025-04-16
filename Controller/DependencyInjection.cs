using Application.Configuration;
using Infrastructure.DependencyInjection;

namespace Controller
{
    public static class DependencyInjection
    {
        public static void AddInfrastruct(this IServiceCollection services)
        {
            services.AddInfrastructureService("Server=localhost;Database=ProTransRemakeDB;User ID=sa;Password=123456");
        }
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddService();
        }
    }
}
