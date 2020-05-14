using CW_3_v2.DAL;
using CW_3_v2.Services;
using CW_3_v2.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CW_3_v2.ModelsFramework;
using Microsoft.EntityFrameworkCore;

namespace CW_3_v2
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
            services.AddScoped<IStudentsDbService, SqlServerDbService>();
            services.AddScoped<IStudentsDbService, EfStudentsDbService>();
            services.AddSingleton<IDbService, MockDbService>();
            services.AddSingleton<IStudentsDbService, SqlServerDbService>();
            services.AddDbContext<s18731Context>(opt => {
                opt.UseSqlServer("Data Source=db-mssql;Initial Catalog=s18731;Integrated Security=True");
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStudentsDbService service)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<LoggingMiddleware>();

            app.Use(async (context, next) =>
            {
                if(!context.Request.Headers.ContainsKey("Index"))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Student index required.");
                }

                string index = context.Response.Headers["Index"].ToString();
                
                //checking if database contains student

                var check = service.IsStudentNumberUnique(index);

                if (!check)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync("Student not found.");
                    return;
                }

                await next();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                IStudentsDbService _dbService = new SqlServerDbService();
                _dbService.IsStudentNumberUnique(context.Response.Headers["Index"].ToString());
                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
