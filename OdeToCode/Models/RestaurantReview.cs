using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToCode.Models
{
    public class RestaurantReview
    {
        public int Id { get; set; }
        public int Raiting { get; set; }
        public string Body { get; set; }
        public int ResturantId { get; set; }
    }
}
