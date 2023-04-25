using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Basket
    {
        public int id_basket { get; set; }
        public int product_id { get; set; }
        public int amountProduct { get; set; }
        public int user_id { get; set; }
        public Products products { get; set; }
    }
}
