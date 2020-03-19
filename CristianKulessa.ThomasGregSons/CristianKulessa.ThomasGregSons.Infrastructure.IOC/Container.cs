using CristianKulessa.ThomasGregSons.Domain.Repositories.Interfaces;
using CristianKulessa.ThomasGregSons.Domain.Services;
using CristianKulessa.ThomasGregSons.Domain.Services.Interfaces;
using CristianKulessa.ThomasGregSons.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CristianKulessa.ThomasGregSons.Infrastructure.IOC
{
    public static class Container
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ILogradouroRepository, LogradouroRepository>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ILogradouroService, LogradouroService>();
        }
    }
}
