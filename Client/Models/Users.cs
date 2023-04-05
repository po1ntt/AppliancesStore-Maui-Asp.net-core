using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Users
    {
        public int id_users { get; set; }
        public string userPhone { get; set; }
        public string userName { get; set; }
        public string userPasswod { get; set; }
        public List<PostponedProduct> postponedProduct { get; set; }
        public List<RecentlyViewed> recentlyViewed { get; set; }
    }
}
