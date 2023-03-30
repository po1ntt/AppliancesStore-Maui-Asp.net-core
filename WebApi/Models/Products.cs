using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Products
    {
        public Products()
        {
            characteristicProducts = new HashSet<CharacteristicProduct>();
        }
        [Key]
        public int id_products { get; set; }
        public string? ProductsName { get; set; }
        public string? ProductsDesсription { get; set; }
        [ForeignKey("Subcategory")]
        public int Subcategory_id { get; set; }
        [ForeignKey("BrandProduct")]
        public int productBrand_id { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public int Quantity { get; set; }
        [InverseProperty("Product")]
        public ICollection<CharacteristicProduct>? characteristicProducts { get; set; }

        public Subcategory Subcategory { get; set; }
        public BrandProduct BrandProduct { get; set; }


    }
}
