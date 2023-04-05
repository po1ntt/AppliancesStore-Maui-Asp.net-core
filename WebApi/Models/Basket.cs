using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class Basket
    {
        [Key]
        public  int id_basket { get; set; }
        [ForeignKey("Products")]

        public int product_id { get; set; }
        public int AmountProduct { get; set; }
        [ForeignKey("Users")]
        public int user_id { get; set; }
        [JsonIgnore]

        public Users? Users { get; set; }
        public Products? Products { get; set; }



    }
}
