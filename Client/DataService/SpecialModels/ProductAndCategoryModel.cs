using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.DataService.DboModels;

namespace Client.DataService.SpecialModels
{
    public class ProductAndCategoryModel
    {
        public string? nameCategory { get; set; }
        public List<Product>? products { get; set; } 
    }
}
