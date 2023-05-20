using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Users
    {

        [Key]
       
        public int id_users { get; set; }

        public string? userPhone { get; set; }
        public string? userName { get; set; }
        public string? UserPasswod { get; set; }

      



    }
}
