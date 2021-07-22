using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sagardemoapi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sagardemoapi
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
            services.AddRazorPages();
            services.AddTransient<IEmployee, EmployeeRepositoryFromDB>();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }


        public void executethiscode(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                   "I got executed because somekey query string is there"
                    );
            });
        }
        public void executethiscode1(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                   "I got executed because of SPECIAL ROUTING\n"
                    );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles(); // static
            
            app.UseRouting();

            //app.UseAuthorization();

         
            app.UseMvcWithDefaultRoute();

            //short circuiting
            // terminal middleware
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    Configuration["mykey"].ToString()
                    );
            });
            // run middleware
            app.Use(async (context,next) =>
            {
                await context.Response.WriteAsync("I am coming from request 1\n");
                await next.Invoke();
                await context.Response.WriteAsync("I am coming from RESPONSE 1\n");
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("I am coming from request 2\n");
                await next.Invoke();
                await context.Response.WriteAsync("I am coming from RESPONSE 2\n");
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("I am coming from request 3\n");
                await next.Invoke();
                await context.Response.WriteAsync("I am coming from RESPONSE 3\n");
            });

            app.Map("/somerouting", executethiscode1);

            app.MapWhen(context => {
                return context.Request.Query.ContainsKey("somekey");
            }, executethiscode);


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    Configuration["mykey"].ToString()
                    );
            });
        }
    }
}
