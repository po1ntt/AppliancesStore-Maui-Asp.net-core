using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Review
    {
        [Key]
        public int id_review { get; set; }

        [ForeignKey("User")]
        public int user_id { get; set; }

        public double Grade { get; set; }
        public string? ReviewText { get; set; }

        public Users? User { get; set; }
    }
}
