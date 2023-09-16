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
                //default ta  projeler development environment �zeirnden projeyi kald�r�r Project-Properties-debug ta bu ayar� hangi env olmas� isteniyorsa ayarlanabilir.
                String env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production" ; //ortam� al�yoruz burada

                return new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json",optional: false) // opsiyonelli�i olmad��� i�in hi�bir �ey bul�amazsa bu dosyaya� okuyacak,
                    .AddJsonFile($"appsettings.{env}.Development.json", optional: true) // Bu sat�ra indi�inde bu dosyaya bakacak opsiyonelli�i "true" oldu�u i�in bu dosytay� bulursa bunu okuyacak bulamazsa opsiyonelli�i false olan dosya hangisiyse onu okuyacak. (env. yi �ekip anl�yoruz ortam�.)
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
