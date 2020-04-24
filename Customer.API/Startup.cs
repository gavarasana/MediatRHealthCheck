using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Customer.Data.DbContext;
using Customer.Data.IRepositories;
using Customer.Data.Repositories;
using Customer.Service.Dxos;
using Customer.Service.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Customer.API1
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
            var customerDbConnection = Configuration.GetConnectionString("CustomerDBConnection");
            var booksDbConnection = Configuration.GetConnectionString("CustomerDBConnection");

            services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseSqlServer(customerDbConnection, optionsBuilder =>
                {
                    optionsBuilder.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(15), 
                        errorNumbersToAdd: null);
                });
            });

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer Api", Version = "v1" });
                s.DescribeAllParametersInCamelCase();                
            });

            // Add DIs
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerDxos, CustomerDxos>();

            services.AddMediatR(typeof(CreateCustomerHandler).GetTypeInfo().Assembly);

            services.AddLogging();

            services.AddControllers();

            services.AddHealthChecks()
                .AddSqlServer(connectionString: customerDbConnection, name: "Customer DB")
               .AddSqlServer(connectionString: booksDbConnection, name: "Books DB");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API V1"); });

            app.UseAuthorization();

            app.UseHealthChecks("/health");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
