using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RestfulQr.Core;
using RestfulQr.Core.Auth;
using RestfulQr.Core.Middleware;
using RestfulQr.Entities;
using RestfulQr.Repositories;
using RestfulQr.Repositories.Impl;
using RestfulQr.Services;
using RestfulQr.Services.Impl;
using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace RestfulQr
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                options.DefaultChallengeScheme = ApiKeyAuthenticationOptions.DefaultScheme;
            }).AddApiKeySupport(options => { });

            services.AddDbContext<RestfulQrDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetSection("Db")["ConnectionString"]);
            });

            services.AddScoped<QrCodeOptions>();
            services.AddScoped<ApiKeyProvider>();

            services.AddScoped<IApiKeyRepository, EfCoreApiKeyRepository>();
            services.AddScoped<ICreatedQrCodeRepository, EfCoreCreatedQrCodeRepository>();

            services.AddScoped<IApiKeyService, ApiKeyService>();
            services.AddScoped<IQrCodeDataService, QrCodeDataService>();
            services.AddScoped<IQrCodeRenderingService, QrCodeRenderingService>();
            services.AddScoped<IQrCodeService, QrCodeService>();
            services.AddScoped<IImageFileService, ImageFileService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestfulQr", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration config, RestfulQrDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestfulQr v1"));

                context.Database.EnsureCreated();

                if (context.ApiKeys.AsNoTracking().CountAsync().Result == 0)
                {
                    context.ApiKeys.Add(new ApiKey
                    {
                        Key = "development",
                        LastUsed = DateTime.Now,
                        DateCreated = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }

            // Check to see if the destination folder exists, and if not, create it
            var imageOutputPath = Path.Combine(env.ContentRootPath, config.GetSection("Images")["Path"]);

            if (!Directory.Exists(imageOutputPath))
            {
                Directory.CreateDirectory(imageOutputPath);
            }

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseQrCodeOptionsExtraction();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
