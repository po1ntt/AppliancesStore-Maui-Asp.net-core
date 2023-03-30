using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class BrandProduct
    {
        [Key]
        public int id_brand { get; set; }
        public  string? NameBrand { get; set; }
    }
}
