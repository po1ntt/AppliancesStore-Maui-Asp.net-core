using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Subcategory
    {
        public int id_subcategory { get; set; }
        public int category_id { get; set; }
        public string nameSubCategory { get; set; }
    }
}
