using Business.Services.Implementations;
using Business.Services.Interfaces;
using EntityGateWay;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBllLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();

            services.AddDalLayer(configuration);

            return services;
        }
    }
}