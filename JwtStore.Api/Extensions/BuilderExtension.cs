using JwtStore.Account.Handlers;
using JwtStore.Account.Repositories;
using JwtStore.Account.Services;
using JwtStore.Infra.Data;
using JwtStore.Infra.Repositories;
using JwtStore.Infra.Services;
using JwtStore.Order.Handlers;
using JwtStore.Order.Repositories;
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
        builder.Services.AddTransient<IUserCreateRepository, UserCreateRepository>();
        builder.Services.AddTransient<UserCreateHandler, UserCreateHandler>();
        builder.Services.AddTransient<IAuthenticateRepository, AuthenticateRepository>();
        builder.Services.AddTransient<AuthenticateHandler, AuthenticateHandler>();
        builder.Services.AddTransient<ICategoryCreateRepository, CategoryCreateRepository>();
        builder.Services.AddTransient<CategoryCreateHandler, CategoryCreateHandler>();
        builder.Services.AddTransient<ICategoryUpdateRepository, CategoryUpdateRepository>();
        builder.Services.AddTransient<CategoryUpdateHandler, CategoryUpdateHandler>();
        builder.Services.AddTransient<IProductCreateRepository, ProductCreateRepository>();
        builder.Services.AddTransient<ProductCreateHandler, ProductCreateHandler>();
        builder.Services.AddTransient<IProductUpdateRepository, ProductUpdateRepository>();
        builder.Services.AddTransient<ProductUpdateHandler, ProductUpdateHandler>();
        builder.Services.AddTransient<IRoleInsertRepository, RoleInsertRepository>();
        builder.Services.AddTransient<RoleInsertHandler, RoleInsertHandler>();
        builder.Services.AddTransient<IRoleCreateRepository, RoleCreateRepository>();
        builder.Services.AddTransient<RoleCreateHandler, RoleCreateHandler>();
        builder.Services.AddTransient<IAddressCreateRepository, AddressCreateRepository>();
        builder.Services.AddTransient<AddressCreateHandler, AddressCreateHandler>();

        builder.Services.AddTransient<IOrderCreateRepository, OrderCreateRepository>();
        builder.Services.AddTransient<OrderCreateHandler, OrderCreateHandler>();
        builder.Services.AddTransient<IOrderItemsInsertRepository, OrderInsertItemsRepository>();
        builder.Services.AddTransient<OrderItemsInsertHandler, OrderItemsInsertHandler>();
        builder.Services.AddTransient<IOrderPaymentRepository, OrderPaymentRepository>();
        builder.Services.AddTransient<OrderPaymentHandler, OrderPaymentHandler>();
        builder.Services.AddTransient<IOrderCloseRepository, OrderCloseRepository>();
        builder.Services.AddTransient<OrderCloseHandler, OrderCloseHandler>();

        builder.Services.AddTransient<ICategorySelectRepository, CategorySelectRepository>();
        builder.Services.AddTransient<IProductSelectRepository, ProductSelectRepository>();
        builder.Services.AddTransient<IRoleSelectRepository, RoleSelectRepository>();
        builder.Services.AddTransient<IAddressSelectRepository, AddressSelectRepository>();
    }
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAuthenticateTokenService, AuthenticateTokenService>();
    }
    public static void AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    public static void UseAppSwagger(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}