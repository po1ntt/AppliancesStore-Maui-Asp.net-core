using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Review
    {
        public int id_review { get; set; }
        public int user_id { get; set; }
        public double grade { get; set; }
        public string reviewText { get; set; }
        public Users user { get; set; }
    }
}
