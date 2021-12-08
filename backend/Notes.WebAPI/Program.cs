using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Notes.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((ctx, config) => { config.ReadFrom.Configuration(ctx.Configuration); })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        if (!hostingContext.HostingEnvironment.IsProduction())
                        {
                            config.AddUserSecrets<Startup>(true);
                        }
                    });
                });
    }
}
