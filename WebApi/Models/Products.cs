using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Products
    {
       
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
        public bool IsNew { get; set; }
        public bool IsTrend { get; set; }


        public int Quantity { get; set; }
        [JsonIgnore]
        public  ICollection<CharacteristicProduct>? CharacteristicProduct { get; set; }
        public  ICollection<ReviewsProduct>? ReviewsProduct { get; set; }
        //[NotMapped]
       // public double? AVGgrade => ReviewsProduct != null ? ReviewsProduct.Average(p => p.Grade) : 0;
        //[NotMapped]
       // public int? CountReviews => ReviewsProduct != null ? ReviewsProduct.Count : 0;

        public string? ProductImageUrl { get; set; }
        [JsonIgnore]
        public Subcategory? Subcategory { get; set; }
        [JsonIgnore]
        public BrandProduct? BrandProduct { get; set; }



    }
}
