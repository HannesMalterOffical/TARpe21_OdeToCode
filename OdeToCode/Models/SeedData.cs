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
                // Look for any movies.
                if (context.Resturants.Any())
                {
                    return;   // DB has been seeded
                }

                context.Resturants.AddRange(
                    new Resturant
                    {
                        Name = "Sabatino's",
                        City = "Baltimore",
                        Country = "USA"

                    },

                    new Resturant
                    {
                        Name = "Great Lake ",
                        City = "Chicago",
                        Country = "USA"

                    },

                    new Resturant
                    {
                        Name = "Paradox Con",
                        City = "Stockholm",
                        Country = "Sweden",
                        Reviews = 
                            new List<RestaurantReview> {
                            new RestaurantReview { Raiting = 9, Body = "Great Food!"}
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}