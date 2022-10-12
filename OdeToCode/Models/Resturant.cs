using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToCode.Models
{
    public class Resturant
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<RestaurantReview> Reviews { get; set; }
    }
}
