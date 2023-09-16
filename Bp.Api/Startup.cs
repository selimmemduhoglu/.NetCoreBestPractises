
using Bp.Api.Extensions;
using Bp.Api.Service;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace Bp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();


            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            //Bunu fluent validation u eklemek için kullandýk.

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bp.Api", Version = "v1" });
            });

            services.ConfigureMapping();

            services.UseServiceCollection(); //scope vs.

            services.AddHttpClient("garantiapi", config =>
            {
                config.BaseAddress = new Uri("http://www.garanti.com");
                config.DefaultRequestHeaders.Add("Authorization","Bearer 122132323325");

            });
         

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bp.Api v1"));
            }


            app.UseCustomHealthCheck(); // startup ý olabilrdiðince sade tutmak gerektiði için static bir class a taþýdýk.


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseResponseCaching(); // responseCache için kullanýlýyor.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "Default", pattern: "{controller=Contact}/{action=Get}/{id?}");
            });
        }
    }
}
