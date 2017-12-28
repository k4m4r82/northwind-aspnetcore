using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Northwind.Repository;
using Swashbuckle.AspNetCore.Swagger;

namespace Northwind.WebAPI
{
    public class Startup
    {
        //public Startup(IHostingEnvironment env)
        //{
        //    Configuration = new ConfigurationBuilder()
        //        .SetBasePath(env.ContentRootPath)
        //        .AddEnvironmentVariables()
        //        .Build();
        //}

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.AddMvcCore()
            //        .AddJsonFormatters();

            //services.AddMvcCore().AddApiExplorer();

            // Enable middleware to serve generated Swagger as a JSON endpoint.

            /*
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Northwind API",
                    Version = "v1",
                    Description = "API to manage Northwind",
                    TermsOfService = "None"
                });
            });*/

            // Register application services.
            //services.AddScoped<IDapperContext, DapperContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1 Northwind");
            });*/

            app.UseMvc();
            //app.UseMvcWithDefaultRoute();
        }
    }
}
