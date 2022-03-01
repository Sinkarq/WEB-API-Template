using YourProject.Infrastructure;
using Microsoft.EntityFrameworkCore;
using YourProject.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetDefaultConnection()))
    .AddIdentity()
    .AddJwtAuthentication(builder.Services.GetApplicationSettings(builder.Configuration))
    .AddApplicationServices()
    .AddSwagger()
    .AddControllers();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}

app
    .UseSwaggerUI()
    .UseRouting()
    .UseAutoMapper()
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


