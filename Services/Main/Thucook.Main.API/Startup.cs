using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Serilog;
using System;
using System.Linq;
using System.Text;
using Thucook.Commons.CustomJsonConverter;
using Thucook.Core;
using Thucook.Core.Implements;
using Thucook.EntityFramework;
using Thucook.Main.API.Filters;
using Thucook.Main.API.Middlewares;
using Thucook.Main.ApiService;
using Thucook.Main.ApiService.Implements;
using ThuCook.Main.ApiService.Implements;

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
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtAudience:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecurityKey"])),
                        ClockSkew = TimeSpan.FromDays(1)
                    };
                    options.MapInboundClaims = false;
                });

            services
                .AddCors(options =>
                {
                    options.AddPolicy("allowAll", builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
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
                            configuration.GetConnectionString("DefaultConnection"),
                            ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))
                        )
                        .EnableDetailedErrors();
                },
                ServiceLifetime.Scoped);
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies().First(t => t.GetName().Name == "Thucook.Main.ApiAction"));
            services
                .AddScoped<IDoctorScheduleService, DoctorScheduleService>()
                .AddScoped<IJwtService, JwtService>()
                .AddScoped<ICurrentContext, CurrentContext>();
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
