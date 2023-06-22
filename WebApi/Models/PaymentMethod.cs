using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public partial class PaymentMethod
    {
        public int IdPayment { get; set; }
        public string? PayMethod { get; set; }
        [JsonIgnore]

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
