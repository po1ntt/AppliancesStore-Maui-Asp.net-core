using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Products
    {
        public int id_products { get; set; }
        public string productsName { get; set; }
        public string productsDesription { get; set; }
        public int subcategory_id { get; set; }
        public int productBrand_id { get; set; }
        public int price { get; set; }
        public bool available { get; set; }
        public int quantity { get; set; }
        public List<CharacteristicProduct> characteristicProduct { get; set; }
        public object reviewsProduct { get; set; }
        public string productImageUrl { get; set; }
        public Subcategory subcategory { get; set; }
        public BrandProduct brandProduct { get; set; }
    }
}
