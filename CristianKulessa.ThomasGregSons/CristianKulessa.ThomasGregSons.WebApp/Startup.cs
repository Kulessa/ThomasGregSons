using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CristianKulessa.ThomasGregSons.Infrastructure.Data.Context;
using CristianKulessa.ThomasGregSons.Infrastructure.IOC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CristianKulessa.ThomasGregSons.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DefaultSqlServerContext>(
                options=>options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultDatabase"))
                    .EnableSensitiveDataLogging()
                );
            services.RegisterServices();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
