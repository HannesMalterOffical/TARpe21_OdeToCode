using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToCode.Models
{
    public class RestaurantReview
    {
        public int Id { get; set; }

        [Range(1, 10)]
        public int Raiting { get; set; }

        [Required]
        [StringLength(1024)]
        public string Body { get; set; }

        [Display(Name = "User Name")]
        [DisplayFormat(NullDisplayText = "anonymous")]
        [StringLength(1024)]
        public string ReviewerName { get; set; }
        public int? RestaurantId { get; set; }
    }
}
