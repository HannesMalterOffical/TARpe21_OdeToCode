using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToCode.Models.Review_Models
{
    public class RestaurantReviewEditViewModel
    {
        public int Id { get; set; }
        public int Raiting { get; set; }
        public string Body { get; set; }
        public int RestaurantId { get; set; }
    }
}
