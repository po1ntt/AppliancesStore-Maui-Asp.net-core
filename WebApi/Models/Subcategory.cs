using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class Subcategory
    {
        [Key]
        public int id_subcategory { get; set; }
        [ForeignKey("Category")]
        public int category_id { get; set; }

        public  string? NameSubCategory { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Category? Category { get; set; }
    }
}
