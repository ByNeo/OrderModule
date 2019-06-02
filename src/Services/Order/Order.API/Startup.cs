using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ordering.Domain.Data.Interface;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Repositories;
using Ordering.Infrastructure.Services;
using Ordering.Infrastructure.Services.Interface;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using Swashbuckle.AspNetCore.Swagger;

namespace Order.API
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
            services.AddTransactionFramework(Configuration);
            services.AddDbContext<OrderContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionString"], b => b.MigrationsAssembly("Order.API"));
            });
            services.AddScoped<ExceptionHandlerMiddleware>();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "Order.API", Version = "v1" });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            var elasticUri = Configuration["ElasticConfiguration:Uri"];

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .Enrich.WithMachineName()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
                {
                    AutoRegisterTemplate = true,
                })
            .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            Log.ForContext<Startup>()
                .Information("<{EventID:l}> Configure Started on {Env} {Application} with {@configuration}",
                               "Startup", env.EnvironmentName, env.ApplicationName, Configuration);


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<OrderContext>();
                context.Database.Migrate();
            }


            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order.API V1");
            });
            app.UseMvc();
        }
    }


    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddTransactionFramework(this IServiceCollection services, IConfiguration configuration)
        {
            // Service
            services.AddScoped<IOrderService, OrderService>();

            // Repository
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

            // Mappers
            //services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            // Connection String
            services.AddDbContext<OrderContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));

            return services;
        }
    }
}
