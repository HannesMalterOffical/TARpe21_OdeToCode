using Microsoft.Extensions.DependencyInjection;
using OdeToCode.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToCode.Models;

namespace OdeToCode.Models
{
    public static class SeedData
    {
            public const string ROLE_ADMIN = "Admin";
        public static void Initialize(IServiceProvider serviceProvider)
        {
           

            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {


                if (context.Restaurants.Any())
                {
                    return;   // DB has been seeded
                }



                context.Restaurants.AddRange(
                    new Restaurant
                    {
                        Name = "Sabatino's",
                        City = "Baltimore",
                        Country = "USA"

                    },

                    new Restaurant
                    {
                        Name = "Great Lake ",
                        City = "Chicago",
                        Country = "USA"

                    },

                    new Restaurant
                    {
                        Name = "Paradox Con",
                        City = "Stockholm",
                        Country = "Sweden",
                        Reviews =
                            new List<RestaurantReview> {
                            new RestaurantReview { Raiting = 9, Body = "Great Food!"}
                            }
                    });
                for (int i = 0; i < 1000; i++)
                {
                    context.Restaurants.AddRange(
                    new Restaurant
                    {
                        Name = $"{i}",
                        City = "Nowhere",
                        Country = "USA"
                    });
                }
                context.SaveChanges();
            }
        }
        public static async Task SeedIdentity(UserManager<OdeToCodeUser> userManager, RoleManager<OdeToCodeRole> roleManager)
        {
            var user = await userManager.FindByNameAsync("kristjan@thkit.ee");
            if (user == null)
            {
                user = new OdeToCodeUser();
                user.Email = "kristjan@thkit.ee";
                user.EmailConfirmed = true;
                user.UserName = "kristjan@thkit.ee";
                var userResult = await userManager.CreateAsync(user);
                if (!userResult.Succeeded)
                {
                    throw new Exception($"User creation failed: {userResult.Errors.FirstOrDefault()}");
                }
                await userManager.AddPasswordAsync(user, "Pa$$w0rd");
            }
            var role = await roleManager.FindByNameAsync(ROLE_ADMIN);
            if (role == null)
            {
                role = new OdeToCodeRole();
                role.Name = ROLE_ADMIN;
                role.NormalizedName = ROLE_ADMIN;
                var roleResult = roleManager.CreateAsync(role).Result;
                if (!roleResult.Succeeded)
                {
                    throw new Exception(roleResult.Errors.First().Description);
                }
            }
            await userManager.AddToRoleAsync(user, ROLE_ADMIN);
        }
    }
}
