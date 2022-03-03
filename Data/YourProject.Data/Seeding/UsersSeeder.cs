using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using YourProject.Data.Models;

namespace YourProject.Data.Seeding
{
    internal class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            // use dbContext and then save the changes
            // this method is called every time the app is runned
        }
    }
}
