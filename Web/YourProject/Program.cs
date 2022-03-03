using YourProject.Infrastructure;
using Microsoft.EntityFrameworkCore;
using YourProject.Data;
using YourProject.Infrastructure.Extensions;
using YourProject.Infrastructure.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetDefaultConnection()))
    .AddIdentity()
    .AddJwtAuthentication(builder.Services.GetApplicationSettings(builder.Configuration))
    .AddApplicationServices()
    .AddSwagger()
    .AddControllers(/*options => 
        options.Filters.Add<ModelOrNotFoundActionFilter>()
        All this does it check if the result that you are returning is null and 
        if it's null it returns NotFoundResult() for you*/);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}

app
    .UseSwaggerUI()
    .SeedDatabase()
    .UseAutoMapper()
    .UseRouting()
    .UseCors(options => options
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod())
    .UseAuthentication()
    .UseAuthorization()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

app.Run();


