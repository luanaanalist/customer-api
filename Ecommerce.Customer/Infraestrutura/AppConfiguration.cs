using Domain.Entities;
using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repository;
using Service.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura
{
    public static class AppConfiguration
    {
        public static void ConfigureApp(IServiceCollection services, Microsoft.Extensions.Configuration.IConfigurationRoot configuration)
        {
            ConfigureRepository(services);
            ConfigureService(services);

        }

        private static void ConfigureRepository(IServiceCollection services)
        {

            services.AddScoped<ICommonRepository<Cliente>, ClienteRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

        }
        private static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ITokenService, TokenService>();

        }
    }
}
