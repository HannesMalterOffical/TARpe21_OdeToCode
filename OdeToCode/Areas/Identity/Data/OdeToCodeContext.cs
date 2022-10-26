//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using OdeToCode.Models;

//namespace OdeToCode.Data
//{
//    public class OdeToCodeContext : IdentityDbContext<IdentityUser>
//    {
//		public class ApplicationDbContext : IdentityDbContext<OdeToFoodUser>
//		{
//			public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//							: base(options)
//			{
//			}
//			public DbSet<RestaurantReview> RestaurantReviews { get; set; }
//			public DbSet<Restaurant> Restaurants { get; set; }
//		}
//	}
