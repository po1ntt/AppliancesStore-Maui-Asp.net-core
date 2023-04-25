using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.DataService
{
    public class CategoryService : BaseService
    {
        public static CategoryService categoryService = new CategoryService();
        public async Task<List<Category>> GetCategories()
        {
            List<Category> Categoryes = new();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Console.WriteLine("504");
                return Categoryes;
            }
            try
            {

                HttpResponseMessage response = await httpclient.GetAsync($"{Adress}/api/Category/GetCategories");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    Categoryes = JsonSerializer.Deserialize<List<Category>>(data, jsonSerializerOptions);
                }
                else
                {
                    Console.WriteLine("202");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Categoryes;
            }
            return Categoryes;
        }
        public async Task<List<Subcategory>> GetSubCategories()
        {
            try
            {
                List<Category> categories = await GetCategories();
                List<Subcategory> subcategories = new();
                foreach(var item in categories)
                {
                    foreach(var subcatero in item.subcategories.ToList())
                    {
                        subcategories.Add(subcatero);
                    }
                }
                return subcategories;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
        }
    }
}
