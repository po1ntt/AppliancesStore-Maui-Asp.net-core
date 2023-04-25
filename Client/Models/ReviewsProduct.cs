using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class ReviewsProduct
    {
        public int id_reviewsproduct { get; set; }
        public int product_id { get; set; }
        public int user_id { get; set; }
        public double grade { get; set; }
        public string reviewText { get; set; }
    }
}
