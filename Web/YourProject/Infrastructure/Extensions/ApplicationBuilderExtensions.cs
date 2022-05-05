using System.Reflection;
using Microsoft.EntityFrameworkCore;
using YourProject.Data;
using YourProject.Data.Seeding;
using YourProject.Server.Features.Cats.Models;

namespace YourProject.Server.Infrastructure.Extensions;

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
    
    public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
        new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();

        return app;
    }

    public static IApplicationBuilder UseAutoMapper(this IApplicationBuilder app)
    {
        AutoMapperConfig.RegisterMappings(typeof(Animal).GetTypeInfo().Assembly);
        
        return app;
    }
}
