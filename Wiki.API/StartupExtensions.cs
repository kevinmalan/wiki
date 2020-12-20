using Wiki.Core.Contexts;
using Wiki.Core.Services;
using Wiki.Core.Services.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Wiki.Common;

namespace Wiki.API
{
    public static class StartupExtensions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(config.GetSection(Db.Wiki).Value));
            services.AddHttpContextAccessor();

            // Custom Services
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IQueryService, QueryService>();
            services.AddTransient<IValidationService, ValidationService>();
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(o =>
              {
                  o.RequireHttpsMetadata = true;
                  o.SaveToken = true;
                  o.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = config[Jwt.Issuer],
                      ValidAudience = config[Jwt.Audiance],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config[Jwt.SecretKey])),
                      ClockSkew = TimeSpan.Zero
                  };
              });
        }

        public static void ConfigureAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(o =>
            {
                o.AddPolicy(Policies.Admin, Policies.AdminPolicy());
                o.AddPolicy(Policies.Member, Policies.MemberPolicy());
            });
        }
    }
}