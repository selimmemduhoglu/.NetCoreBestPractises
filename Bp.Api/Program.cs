using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bp.Api
{
    public class Program
    {
        private static IConfiguration Configuration
        {
            get
            {
                //default ta  projeler development environment üzeirnden projeyi kaldýrýr Project-Properties-debug ta bu ayarý hangi env olmasý isteniyorsa ayarlanabilir.
                String env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production" ; //ortamý alýyoruz burada

                return new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json",optional: false) // opsiyonelliði olmadýðý için hiçbir þey bulþamazsa bu dosyayaý okuyacak,
                    .AddJsonFile($"appsettings.{env}.Development.json", optional: true) // Bu satýra indiðinde bu dosyaya bakacak opsiyonelliði "true" olduðu için bu dosytayý bulursa bunu okuyacak bulamazsa opsiyonelliði false olan dosya hangisiyse onu okuyacak. (env. yi çekip anlýyoruz ortamý.)
                    .AddEnvironmentVariables()
                    .Build();
            }
        }



        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
