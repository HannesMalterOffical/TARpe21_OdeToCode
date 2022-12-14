using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToCode.Models
{
    public class  MaxWordsAttribute:ValidationAttribute
    {
        private readonly int _maxWords;
        public MaxWordsAttribute(int maxWords) : base( "{0} has too many words.") 
        {
            _maxWords = maxWords;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value!=null)
            {
                var valueAsString = value.ToString();
                if (valueAsString.Split(' ').Length > _maxWords)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return base.IsValid(value, validationContext);
        }
    }

    public class RestaurantReview : IValidatableObject
    {
        public int Id { get; set; }

        [Range(1, 10)]
        public int Raiting { get; set; }

        [Required(ErrorMessageResourceType =typeof(Resources.Models.RestaurantReview),
            ErrorMessageResourceName = "Required")]

        [StringLength(1024)]
        public string Body { get; set; }

        [Display(Name = "User Name")]
        [DisplayFormat(NullDisplayText = "anonymous")]
        [StringLength(1024)]
        public string ReviewerName { get; set; }
        public int? RestaurantId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Raiting<2&&ReviewerName.ToLower().StartsWith("scott"))
            {
                yield return new ValidationResult("sorry,you can't do that");
            }
        }
    }
    
}
