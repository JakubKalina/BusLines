using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Data.UnitOfWork;
using Logic.Infrastructure;
using Logic.Infrastructure.Interfaces;
using Logic.Services;
using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusLines
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
            services.AddDbContext<LinieAutobusoweContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BusLines")));

            services.AddMvc();

            services.AddScoped<IGenericRepository<BusStops>, GenericRepository<BusStops>>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<IGenericRepository<Lines>, GenericRepository<Lines>>();
            services.AddScoped<IGenericRepository<Rides>, GenericRepository<Rides>>();
            services.AddScoped<IGenericRepository<RouteSections>, GenericRepository<RouteSections>>();
            services.AddScoped<IGenericRepository<Shifts>, GenericRepository<Shifts>>();
            services.AddScoped<IGenericRepository<Tickets>, GenericRepository<Tickets>>();
            services.AddScoped<IGenericRepository<Vehicles>, GenericRepository<Vehicles>>();
            services.AddScoped<IGenericRepository<VisitedBusStops>, GenericRepository<VisitedBusStops>>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IUserManager, UserManager>();

            services.AddScoped<IPasswordHasher, PasswordHasher>();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => {
                options.LoginPath = "/Account/Login/";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
