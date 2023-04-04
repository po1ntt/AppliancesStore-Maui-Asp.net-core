using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Category
    {
        public int id_categoryProduct { get; set; }
        public string categoryName { get; set; }
        public List<Subcategory> subcategories { get; set; }
    }
}
