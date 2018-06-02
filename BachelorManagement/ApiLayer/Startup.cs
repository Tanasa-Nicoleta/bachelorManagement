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
            services.AddScoped<IBachelorThemeService, BachelorThemeService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentReplyService, CommentReplyService>();
            services.AddScoped<IMeetingRequestService, MeetingRequestService>();
            services.AddScoped<IConsultationService, ConsultationService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
       
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