using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DataService.Constants
{
    public class UrlsApi
    {
        public const string ADRESS = "http://192.168.0.114:5067";
        public const string GETCATEGOTIES_URL = $"{ADRESS}/api/Specific/GetCategory";
        public const string GETBRANDS_URL = $"{ADRESS}/api/Specific/GetBrands";
        public const string UpdateProductCntPlus_URL = $"{ADRESS}/api/Basket/UpdateProductPlus";
        public const string UpdateProductCntMinus_URL = $"{ADRESS}/api/Basket/UpdateProductMinus";
        public const string GETPRODUCTSANDCATEGORY_URL = $"{ADRESS}/api/Specific/GetCategoryAndProducts";

        public static string ProductByBrand(int id_brand)
        {
            return $"{ADRESS}/api/Product/GetProductsByBrand?id_brand={id_brand}";
        }
        public static string ProductByCategory(int id_category)
        {
            return $"{ADRESS}/api/Product/GetProductByCategory?id_category={id_category}";
        }
        public static string RemoveProductFromBasket(int id_basket)
        {
            return $"{ADRESS}/api/Basket/DeleteProductFromBasket?id_basket={id_basket}";
        }


    }
}
