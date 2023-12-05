using JwtStore.Account.Handlers;
using JwtStore.Account.Repositories;
using JwtStore.Account.Services;
using JwtStore.Infra.Data;
using JwtStore.Infra.Repositories;
using JwtStore.Infra.Services;
using JwtStore.Shared;
using JwtStore.Stock.Handlers;
using JwtStore.Stock.Repositories;
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
        var key = Encoding.ASCII.GetBytes(Configuration.Secrets.JwtPrivateKey);
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }
    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAccountCreateUserRepository, AccountCreateUserRepository>();
        builder.Services.AddTransient<AccountCreateUserHandler, AccountCreateUserHandler>();
        builder.Services.AddTransient<IAccountAuthenticateRepository, AccountAuthenticateRepository>();
        builder.Services.AddTransient<AccountAuthenticateHandler, AccountAuthenticateHandler>();
        builder.Services.AddTransient<ICategoryCreateRepository, CategoryCreateRepository>();
        builder.Services.AddTransient<CategoryCreateHandler, CategoryCreateHandler>();
        builder.Services.AddTransient<ICategoryUpdateRepository, CategoryUpdateRepository>();
        builder.Services.AddTransient<CategoryUpdateHandler, CategoryUpdateHandler>();
        builder.Services.AddTransient<IProductCreateRepository, ProductCreateRepository>();
        builder.Services.AddTransient<ProductCreateHandler, ProductCreateHandler>();
        builder.Services.AddTransient<IProductUpdateRepository, ProductUpdateRepository>();
        builder.Services.AddTransient<ProductUpdateHandler, ProductUpdateHandler>();
        builder.Services.AddTransient<IAccountInsertRoleRepository, AccountInsertRoleRepository>();
        builder.Services.AddTransient<AccountInsertRoleHandler, AccountInsertRoleHandler>();
        builder.Services.AddTransient<IAccountCreateRoleRepository, AccountCreateRoleRepository>();
        builder.Services.AddTransient<AccountCreateRoleHandler, AccountCreateRoleHandler>();
        builder.Services.AddTransient<ICategorySelectRepository, CategorySelectRepository>();
        builder.Services.AddTransient<IProductSelectRepository, ProductSelectRepository>();
        builder.Services.AddTransient<IAccountSelectRoleRepository, AccountSelectRoleRepository>();
    }
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAccountAuthenticateTokenService, AccountAuthenticateTokenService>();
    }
}