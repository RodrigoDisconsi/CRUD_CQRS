using CRUDCleanArchitecture.Application.Common.Interfaces;
using CRUDCleanArchitecture.Infrastructure.Identity;
using CRUDCleanArchitecture.Infrastructure.Persistence;
using CRUDCleanArchitecture.Infrastructure.Persistence.Dapper;
using CRUDCleanArchitecture.Infrastructure.Services;
using CRUDCleanArchitecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        //if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        //{
        //    services.AddDbContext<ApplicationDbContext>(options =>
        //        options.UseInMemoryDatabase("CRUDCleanArchitectureDb"));
        //}
        //else
        //{
        //    services.AddDbContext<ApplicationDbContext>(options =>
        //        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        //            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        //}

        //services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        //services.AddScoped<ApplicationDbContextInitialiser>();

        //services
        //    .AddDefaultIdentity<ApplicationUser>()
        //    //.AddRoles<IdentityRole>()
        //    .AddEntityFrameworkStores<ApplicationDbContext>();

        ////services.AddIdentityServer()
        ////    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        //services.AddTransient<IDateTime, DateTimeService>();
        ////services.AddTransient<IIdentityService, IdentityService>();
        ////services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

        ////services.AddAuthentication()
        ////    .AddIdentityServerJwt();

        ////services.AddAuthorization(options =>
        ////    options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        //return services;

        services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(
              configuration.GetConnectionString("EFCoreDatabase"),
              b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddPersistenceDapper(configuration);

        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

        services.AddScoped<IDomainEventService, DomainEventService>();

        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();

        services.AddRepositories();

        //services.AddAuthorizationPolicies();

        return services;
    }
}
