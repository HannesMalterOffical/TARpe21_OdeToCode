using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToCode.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var data = new Restaurant();
            data.Reviews = new List<RestaurantReview>();
            data.Reviews.Add(new RestaurantReview() { Raiting = 4});

            var rater = new RestaurantRater(data);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(4, result.Rating);
        }
    }
}
