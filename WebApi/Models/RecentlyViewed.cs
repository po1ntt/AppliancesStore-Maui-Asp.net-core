using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class RecentlyViewed
    {
        [Key]
        public int id_recentlyViewed { get; set; }
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
