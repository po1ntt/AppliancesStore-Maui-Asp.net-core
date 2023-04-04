using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class ReviewsProduct
    {
        [Key]
        public int id_reviewsproduct { get; set; }
        [ForeignKey("Reviews")]

        public int reviews_id { get; set; }
        [ForeignKey("Products")]

        public int product_id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Products? Products { get; set; }
        public Review? Review { get; set; }

    }
}
