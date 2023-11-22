using JwtStore.Account;
using JwtStore.Account.Handlers;
using JwtStore.Account.Repositories;
using JwtStore.Account.Services;
using JwtStore.Infra.Data;
using JwtStore.Infra.Repositories;
using JwtStore.Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JwtStore.Api.Extensions;

public static class BuilderExtension
{
    public static void AddControllers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
    }
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.Database.ConnectionString =
            builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

        Configuration.Secrets.ApiKey =
            builder.Configuration.GetSection("Secrets").GetValue<string>("ApiKey") ?? string.Empty;
        Configuration.Secrets.JwtPrivateKey =
            builder.Configuration.GetSection("Secrets").GetValue<string>("JwtPrivateKey") ?? string.Empty;
        Configuration.Secrets.PasswordSaltKey =
            builder.Configuration.GetSection("Secrets").GetValue<string>("PasswordSaltKey") ?? string.Empty;
    }
    public static void AddDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Configuration.Database.ConnectionString,
                                                    b => b.MigrationsAssembly("JwtStore.Infra")));
    }
    public static void AddJwtAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.Secrets.JwtPrivateKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        builder.Services.AddAuthorization();
    }
    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAccountCreateRepository, AccountCreateRepository>();
        builder.Services.AddTransient<AccountCreateHandler, AccountCreateHandler>();
        builder.Services.AddTransient<IAccountAuthenticateRepository, AccountAuthenticateRepository>();
        builder.Services.AddTransient<AccountAuthenticateHandler, AccountAuthenticateHandler>();
    }
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAccountAuthenticateTokenService, AccountAuthenticateTokenService>();
    }
}