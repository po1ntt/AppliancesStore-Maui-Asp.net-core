using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Category
    {
        [Key]
        public int id_categoryProduct { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryImage { get; set; }
        public ICollection<Subcategory>? Subcategories { get; set; }
    }
}
