using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using Homer.Api.Data.Context;
using Homer.Api.CrossCutting.IOC;
using Microsoft.EntityFrameworkCore;
using System;
using Homer.Api.Domain.Helpers;

namespace Homer.Api.App
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

            services.AddControllers();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMemoryCache();
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);
            services.AddResponseCompression(option => { option.Providers.Add<GzipCompressionProvider>(); });

            ConfigureService.ConfigureDependeciesService(services);
            ConfigureRepository.ConfigureDependeciesRepository(services);

            string conStr = Configuration.GetConnectionString("DefaultConnection");
            BaseContextHelpers.SetConnectionStr(conStr);

            var serverVersion = new MySqlServerVersion(new Version(5, 7, 17));
            services.AddDbContextPool<BaseContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(conStr, serverVersion)
                    .EnableDetailedErrors()
            );

            var ver = ServerVersion.AutoDetect(conStr);
            services.AddDbContext<BaseContext>(options => options.UseMySql(conStr, ver));

            //CORS

            string[] hostPermitido = new string[] { "*", "http://localhost:3000", "http://localhost:3001" };

            services.AddCors(options =>
            {
                options.AddPolicy("PolicyCORS", builder => builder
                    .WithOrigins(hostPermitido)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("PolicyCORS");
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
