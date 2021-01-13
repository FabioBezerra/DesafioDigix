using System.Globalization;
using Desafio.Domain.FamiliaDomain.Interfaces.Services;
using Desafio.Domain.FamiliaDomain.Services;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Desafio.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Desafio API";
                    document.Info.Description = "Desafio utilizando ASP.NET Core web API";                    
                };
            });
            services.AddSingleton(provider => Configuration);
            ConfigureServicesIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");
        }

        private void ConfigureServicesIoC(IServiceCollection services)
        {
            services.AddScoped(typeof(IVerificadorDeBeneficioPorFamilia), typeof(VerificadorDeBeneficioPorFamilia));
        }
    }
}
