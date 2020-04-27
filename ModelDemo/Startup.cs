using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelDemo.Models;

namespace ModelDemo
{
    public class Startup
    {

        private IConfiguration _config;


        public Startup(IConfiguration config)
        {
            _config = config; 
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940


        public void ConfigureServices(IServiceCollection services)
        {
            /*
             * Registering Services

                ASP.NET core provides the following 3 methods to register services with the dependency injection container. The method that we use determines the lifetime of the registered service.

                AddSingleton() - As the name implies, AddSingleton() method creates a Singleton service. A Singleton service is created when it is first requested. This same instance is then used by all the subsequent requests. So in general, a Singleton service is created only one time per application and that single instance is used throughout the application life time.

                 AddTransient() - This method creates a Transient service. A new instance of a Transient service is created each time it is requested. 

                AddScoped() - This method creates a Scoped service. A new instance of a Scoped service is created once per request within the scope. For example, in a web application it creates 1 instance per each http request but uses the same instance in the other calls within that same web request.

                */

            services.AddDbContextPool<AppDbContext>(
             options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));

            services.AddScoped<IEmployeeRepository, SqlEmployeeRepository>();

            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}

//https://www.learnentityframeworkcore.com/migrations/commands/pmc-commands
//https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/