﻿using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YourProject.Data;
using YourProject.Services.Mapping;
using YourProject.ViewModels;

namespace YourProject.Infrastructure.Extensions;

public static class ApplicationBuilderExtensions
{   
    public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
    {
        return app.UseSwagger()
            .UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "YourProject V1");
                options.RoutePrefix = string.Empty;
            });
    }

    public static IApplicationBuilder UseAutoMapper(this IApplicationBuilder app)
    {
        AutoMapperConfig.RegisterMappings(typeof(Animal).GetTypeInfo().Assembly);
            
        return app;
    }
        
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var services = app.ApplicationServices.CreateScope();

        var dbContext = services.ServiceProvider.GetService<ApplicationDbContext>();

        dbContext?.Database.Migrate();
    }
}