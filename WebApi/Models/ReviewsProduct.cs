using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class ReviewsProduct
    {
        [Key]
        public int id_reviewsproduct { get; set; }
     
        [ForeignKey("Products")]

        public int product_id { get; set; }
        [ForeignKey("Users")]
        public int user_id { get; set; }

        public double Grade { get; set; }
        public string? ReviewText { get; set; }
        public Users? Users { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]

        public Products? Products { get; set; }

    }
}
