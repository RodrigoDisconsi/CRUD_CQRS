﻿using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
//using Prestadores.Api.Filters;
//using Prestadores.Api.Services;
//using Prestadores.Infrastructure.Persistence;
//using Prestadores.Application.Common.Interfaces.Services;
using CRUDCleanArchitecture.Application.Common.Interfaces;
using CRUDCleanArchitecture.Infrastructure.Persistence;
using API.Services;
using API.Filters;

namespace API
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            var CorsAllowedOrigins = "AllowSpecificOrigins";
            services.AddControllers(options =>
            {
                options.Filters.Add<ApiExceptionFilterAttribute>();
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsAllowedOrigins,
                                  builder =>
                                  {
                                      var origins = configuration.GetValue<string>("CorsOrigins").Split(",");
                                      builder.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod();
                                  });
            });
            services.AddFluentValidationAutoValidation();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddHttpContextAccessor();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            return services;
        }
    }
}
