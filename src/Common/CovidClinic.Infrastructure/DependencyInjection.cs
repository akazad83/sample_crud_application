using System;
using System.Text;
using CovidClinic.Application.Common.Interfaces;
using CovidClinic.Infrastructure.Identity;
using CovidClinic.Infrastructure.Persistence;
using CovidClinic.Infrastructure.Services;
using CovidClinic.Infrastructure.Services.Handlers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CovidClinic.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var provider = configuration.GetValue("DbProvider", "SqlServer");
            var migrationAssembly = $"CovidClinic.Infrastructure.{provider}";
            services.AddDbContext<ApplicationDbContext>(options => _ = provider switch
            {
                "Sqlite" => options.UseSqlite(
                    configuration.GetConnectionString("DefaultConnection_Sqlite"),
                    b =>
                    {
                        b.MigrationsAssembly(migrationAssembly);
                    }),

                "SqlServer" => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b =>
                    {
                        b.MigrationsAssembly(migrationAssembly);
                    }),

                "Npgsql" => options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection_Postgres"),
                    b =>
                    {
                        b.MigrationsAssembly(migrationAssembly);
                    }),

                _ => throw new Exception($"Unsupported provider: {provider}")
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddScoped<IDomainEventService, DomainEventService>();

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddTransient<IHttpClientHandler, HttpClientHandler>();
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ITokenService, TokenService>();

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = configuration["JWT:ValidAudience"],
                        ValidIssuer = configuration["JWT:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                    };
                })
                .AddIdentityServerJwt();

            return services;
        }
    }
}
