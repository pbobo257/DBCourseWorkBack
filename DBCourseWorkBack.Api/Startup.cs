using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DBCourseWorkBack.Api.Middlewares;
using DBCourseWorkBack.BusinessLogic.Abstractions;
using DBCourseWorkBack.BusinessLogic.Services;
using DBCourseWorkBack.Infrastructure;
using DBCourseWorkBack.Infrastructure.Abstractions;
using DBCourseWorkBack.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DBCourseWorkBack.Api
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
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SupermarketDB")));

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api V1");
            });
            
            //app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseRouting();

            app.UseCors(c =>
            {
                c.AllowAnyOrigin();
                c.AllowAnyMethod();
                c.AllowAnyHeader();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
