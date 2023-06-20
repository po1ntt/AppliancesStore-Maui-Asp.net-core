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
        public const string ADDPRODUCTTOFAVORITE_URL = $"{ADRESS}/api/Product/AddProductToFavorite";
        public const string ADDPRODUCTTOBASKT_URL = $"{ADRESS}/api/Basket/AddProductToBasket";
        ///api/Product/DeleteProductFromFavorite?id_user=1&id_product=18
        public static string ProductByBrand(int id_brand)
        {
            return $"{ADRESS}/api/Product/GetProductsByBrand?id_brand={id_brand}";
        }
        public static string DeleteFromFavoriteProduct(int id_user, int id_product)
        {
            return $"{ADRESS}/api/Product/DeleteProductFromFavorite?id_user={id_user}&id_product={id_product}";
        }
        public static string FavoritesUser(int id_user)
        {
            return $"{ADRESS}/api/Users/GetFavoritesUser?userid={id_user}";
        }
        public static string BasketUser(int id_user)
        {
            return $"{ADRESS}/api/Basket/GetBasket?userid={id_user}";
        }
        public static string AuthorizeUser(string login ,string password)
        {
            return $"{ADRESS}/api/Users/AuthorizeUser?login={login}&password={password}";

        }
        public static string ProductByCategory(int id_category)
        {
            return $"{ADRESS}/api/Product/GetProductByCategory?id_category={id_category}";
        }
        public static string DeleteFromBasketProduct(int id_user, int id_product)
        {
            return $"{ADRESS}/api/Basket/DeleteProductFromBasket?id_user={id_user}&id_product={id_product}";
        }


    }
}
