using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

namespace Bp.Api.Extensions
{
    public static class HealtCheckConfigureExtension
    {
        public static IApplicationBuilder UseCustomHealthCheck(this IApplicationBuilder app)
        {
            // Bu middleware in işlevi : ne zaman bu path e istek yapılırsa "api/health" , HealthCheckOptions içinde asenkron olarak ResponseWriter sayesinde default bir "OK" dönsün demek. 
            // Bu UseHealthChecks middle ware i sayesinde uygulamama yapılan istek sonucunda uygulamam ayaktaysa OK cevabı dönücem eğer ki ayakta değilse ok cevabı dönemeyeceğim için uygulamamın sağlık durumunu bildirm,iş oluyorum.
            app.UseHealthChecks("/api/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
            {
                ResponseWriter = async (context, report) =>
                {
                    await context.Response.WriteAsync("OK");
                }

            });

            return app;

        }

    }
}
