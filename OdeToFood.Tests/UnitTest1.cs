using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToCode.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OdeToFood.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Computes_Result_For_One_Reviews()
        {
            var data = BuildRestaurantAndReviews(4);

            var rater = new RestaurantRater(data);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(4, result.Raiting);
        }
        [TestMethod]
        public void Computes_Result_For_Two_Reviews()
        {
            var data = BuildRestaurantAndReviews(4, 8);

            var rater = new RestaurantRater(data);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(6, result.Raiting);
        }

        [TestMethod]
        public void Weighted_Averaging_For_Two_Reviews()
        {
            var data = BuildRestaurantAndReviews(3, 9);
            var rater = new RestaurantRater(data);
            var result = rater.ComputeWeightedRate(10);

            Assert.AreEqual(5, result.Raiting);
        }

        private Restaurant BuildRestaurantAndReviews(params int[] raitings)
        {
            var result = new Restaurant();
            result.Reviews = raitings.Select(r => new RestaurantReview { Raiting = r }).ToList();

            return result;
        }
        
    }
}
