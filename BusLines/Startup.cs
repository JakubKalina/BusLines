using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusLines.Models;
using BusLines.Repositories;
using BusLines.Repositories.Interfaces;
using BusLines.UnitOfWork;
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
            var connection = @"Server=LAPTOP-J1STRQHS\JAKUBKALINA; Database = LinieAutobusowe; Trusted_Connection=True;";

            services.AddDbContext<LinieAutobusoweContext>(options => options.UseSqlServer(connection));

            services.AddMvc();

            services.AddScoped<IGenericRepository<BusStops>, GenericRepository<BusStops>>();
            services.AddScoped<IGenericRepository<Employees>, GenericRepository<Employees>>();
            services.AddScoped<IGenericRepository<Lines>, GenericRepository<Lines>>();
            services.AddScoped<IGenericRepository<Rides>, GenericRepository<Rides>>();
            services.AddScoped<IGenericRepository<RouteSections>, GenericRepository<RouteSections>>();
            services.AddScoped<IGenericRepository<Shifts>, GenericRepository<Shifts>>();
            services.AddScoped<IGenericRepository<Tickets>, GenericRepository<Tickets>>();
            services.AddScoped<IGenericRepository<Vehicles>, GenericRepository<Vehicles>>();
            services.AddScoped<IGenericRepository<VisitedBusStops>, GenericRepository<VisitedBusStops>>();

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();


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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
