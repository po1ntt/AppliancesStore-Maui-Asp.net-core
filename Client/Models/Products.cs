using Client.DataService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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
        public double price { get; set; }
        public bool available { get; set; }
        public bool isNew { get; set; }
        public bool isTrend { get; set; }
        public int quantity { get; set; }
        public List<CharacteristicProduct> characteristicProduct { get; set; }
        public List<ReviewsProduct> reviewsProduct { get; set; }
        public string productImageUrl { get; set; }

      

        public Subcategory subcategory { get; set; }
        public BrandProduct brandProduct { get; set; }

      
    }
}
