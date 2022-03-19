using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Serilog;
using System;
using System.Linq;
using Thucook.Commons.CustomJsonConverter;
using Thucook.EntityFramework;
using Thucook.Main.API.Filters;
using Thucook.Main.API.Middlewares;

namespace Thucook.Main.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //AppSettings = new AppSetting();
            //Configuration.Bind(AppSettings);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<AppSetting>(Configuration);

            services
                .Configure<RouteOptions>(options =>
                {
                    options.LowercaseUrls = true;
                    options.AppendTrailingSlash = true;
                })
                .Configure((Action<ApiBehaviorOptions>)(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                }));

            services
                .AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.MaxModelValidationErrors = 10;
                    options.Filters.Add<ValidateModelFilter>();
                    options.Filters.Add<CustomExceptionResponseFilter>();
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.Converters.Add(new CustomGuidConverter());
                });

            services
                .AddCors(options =>
                {
                    options.AddPolicy("allowAll", builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            ;
                    });
                })
                .AddResponseCompression();

            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Thucook.Main.API", Version = "v1" });
                });

            services
                .AddLogging()
                .AddOptions()
                .AddHttpContextAccessor();

            services
                .AddDbContext<ThucookContext>(options =>
                {
                    options
                        .UseMySql(
                            "server=localhost;port=3306;database=thru_cook;uid=root;password=Hung2001@;",
                            ServerVersion.AutoDetect("server=localhost;port=3306;database=thru_cook;uid=root;password=Hung2001@;")
                        )
                        .EnableDetailedErrors();
                },
                ServiceLifetime.Scoped);

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies().First(t => t.GetName().Name == "Thucook.Main.ApiAction"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizationOptions.Value);

            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseSwagger()
                .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Thucook.Main.API v1"))
                .UseCors("allowAll")
                .UseResponseCompression();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<RequestInputLoggingMiddleware>();
            app.UseMvc();
        }
    }
}
