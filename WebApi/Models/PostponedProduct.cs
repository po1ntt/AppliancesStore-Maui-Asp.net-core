using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class PostponedProduct
    {
        [Key]
        public int id_postponedproducct { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]

        [ForeignKey("Users")]
        public int user_id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]

        [ForeignKey("Products")]
        public int product_id { get; set; }
        public Products? Products { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Users? Users { get; set; }
    }
}
