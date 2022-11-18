using OdeToCode.Models;
using System;

namespace OdeToFood.Tests
{
    public class RestaurantRater
    {
        private Restaurant data;
        private object _restaurant;

        public RestaurantRater(Restaurant restaurant)
        {
            _restaurant = restaurant;
        }

        public RatingResult ComputeRating(int numberOfReviews)
        {
            var result = new RatingResult();
            result.Rating = 4;

            return new RatingResult() { Rating = 4 };
        }
    }
}