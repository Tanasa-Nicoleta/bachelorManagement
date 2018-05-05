using BachelorManagement.BusinessLayer.Services;
using BachelorManagement.DataLayer;
using BachelorManagement.DataLayer.Repositories;
using BachelorManagement.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BachelorManagement.ApiLayer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddMvc();

            services.AddEntityFrameworkSqlServer().AddDbContext<BachelorManagementContext>();
            services.AddScoped(p => new DbContext(p.GetService<DbContextOptions<BachelorManagementContext>>()));

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            BachelorManagementContext context)
        {
            BachelorManagementInitializeDb.Initialize(context);

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler();

            app.UseCors("CorsPolicy");

            app.UseMvcWithDefaultRoute();
        }
    }
}