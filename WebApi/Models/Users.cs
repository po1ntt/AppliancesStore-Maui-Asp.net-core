using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Users
    {
        public Users()
        {
            RecentlyViewed = new HashSet<RecentlyViewed>();
            PostponedProduct = new HashSet<PostponedProduct>();
        }

        [Key]
       
        public int id_users { get; set; }

        public string? userPhone { get; set; }
        public string? userName { get; set; }
        public string? UserPasswod { get; set; }

        public ICollection<PostponedProduct> PostponedProduct { get; set; }

        public ICollection<RecentlyViewed> RecentlyViewed { get; set; }


    }
}
