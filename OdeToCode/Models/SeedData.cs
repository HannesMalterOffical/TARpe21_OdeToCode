using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OdeToCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToCode.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Restaurants.Any())
                {
                    return;   // DB has been seeded
                }

                //public static void SeedIdentity(UserMananger<OdeToCodeUser> userMananger, RoleMananger<IdentityRole> roleMananger)
                //{
                //    var user = UserManager.FindByNameAsync("hannesmalter1234@gmail.com").Result;
                //    if (user==null)
                //    {
                //        user = new OdeToCodeUser();
                //        user.Email = "hannesmalter1234@gmail.com";
                //        user =
                //        user =
                //    }
                //}
                role = new IdentityRole("Admin");
                IdentityResult result = RoleManager.CreateAsync(role).Result;
                if (role==null)
                {
                    
                    
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
    }
}