using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SFHype.Models;
using System;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;

namespace SFHype
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

            services.AddDbContext<ShopContext>(opt =>
                opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
            services.AddControllers();
            services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SFHype API",
        Description = "SFHype is a RESTful API that allows users to GET, POST, and track the best shops in the San Francisco metro area",
        Contact = new OpenApiContact
        {
            Name = "Connor Burgess",
            Email = "Connorburgesscodes@gmail.com",
            Url = new Uri("https://github.com/ConnorBurgess"),
        },
        License = new OpenApiLicense
        {
            Name = "Licensed under MIT license",
            Url = new Uri("https://mit-license.org/"),
        }

    });
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "SFHype.xml");
    c.IncludeXmlComments(filePath);
});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}