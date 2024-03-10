using OrderPurches.WebApi.Features.Auth;
using OrderPurches.WebApi.Features.Common;
using OrderPurches.WebApi.Features.Users;
using OrderPurches.WebApi.Features.Users.Services;
using OrderPurches.WebApi.Helpers;
using OrderPurches.WebApi.Infraestructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OrderPurches.WebApi.Features.Documents.Services;
using OrderPurches.WebApi.Features.DataMaster.Services;
using OrderPurches.WebApi.Features.Orders.Service;
using OrderPurches.WebApi.Features.ServiceLayer.Services;

namespace OrderPurches.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configuración de Swagger para documentación de la API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderPurches.WebApi", Version = "v1" });
            });

            // Configuración del contexto de base de datos
            services.AddDbContext<OrderPurchesDbContext>(
                dbContextOptions => dbContextOptions
                    .UseSqlServer(Configuration.GetConnectionString("dbOrderPurches"))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );

            // Registro de servicios mediante inyección de dependencias
            services.AddScoped<HanaDbContext>();
            services.AddTransient<AuthService, AuthService>();
            services.AddTransient<UserService, UserService>();
            services.AddTransient<CommonService, CommonService>();
            services.AddTransient<RoleService, RoleService>();
            services.AddTransient<PermissionService, PermissionService>();
            services.AddTransient<DocumentService, DocumentService>();
            services.AddTransient<DataMasterService, DataMasterService>();
            services.AddTransient<OrderServices, OrderServices>();
            services.AddTransient<AuthSapServices, AuthSapServices>();
            services.AddTransient<OrderPurchaseServices, OrderPurchaseServices>();

            // Configuración de autenticación mediante token
            services.AddTokenAuthentication(Configuration);

            // Agrega controladores MVC a los servicios
            services.AddControllers();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderPurchesApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Habilitamos los cors para usar en la web OJO Solo en pruebas en produccion hay que especificiar el origen
            app.UseCors(x => x
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderPurches.WebApi v1"));
            app.UseAuthentication();
            app.UseAuthorization();
       

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
