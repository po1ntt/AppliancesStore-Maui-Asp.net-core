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
        public int reviews_id { get; set; }
        public int product_id { get; set; }
        public Review review { get; set; }
    }
}
