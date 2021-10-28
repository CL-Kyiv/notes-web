using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notes.Core.Configuration;
using Notes.Domain.Services;
using Notes.Domain.Services.Abstractions;
using Notes.Repository.Abstractions.Repositories;
using Notes.Repository.Repositories;

namespace Notes.WebAPI
{
    public class Startup
    {
        readonly string AllowAll = "_allowAllPolicyName";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowAll,
                    builder =>
                    {
                        builder.WithOrigins("*");
                    });
            });

            services.AddControllers();

            string connectionString = GetDbConnectionString(services);
            
            services.AddScoped<INoteRepository, NoteRepository>(provider => new NoteRepository(connectionString));
            services.AddScoped<INoteService, NoteService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(AllowAll);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private string GetDbConnectionString(IServiceCollection services)
        {
            var dbConfig =
                Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
            
            var connectionString = $"Server={dbConfig.Server};Database={dbConfig.Database};User Id={dbConfig.User};Password={dbConfig.Pass};";

            return connectionString;
        }
    }
}
