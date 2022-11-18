using OdeToCode.Models;
using System;
using System.Linq;

namespace OdeToFood.Tests
{
    public class RestaurantRater
    {
        private Restaurant _restaurant;

        public RestaurantRater(Restaurant restaurant)
        {
            _restaurant = restaurant;
        }

        public RatingResult ComputeRating(int numberOfReviews)
        {
            var result = new RatingResult();
            result.Raiting = (int)_restaurant.Reviews.Average(r => r.Raiting);
            return result;
        }

        public RatingResult ComputeWeightedRate(int numberOfReviews)
        {
            var reviews = _restaurant.Reviews.ToArray();
            var result = new RatingResult();
            var counter = 0;
            var total = 0;

            for (int i = 0; i < reviews.Length; i++)
            {
                if (i<reviews.Length/2)
                {
                    counter += 2;
                    total += reviews[i].Raiting * 2;
                }
                else
                {
                    counter++;
                    total += reviews[i].Raiting;
                }
            }
            result.Raiting = total / counter;
            return result;  
        }
    }
}