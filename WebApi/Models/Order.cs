using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public string? OrderNumber { get; set; }

    public DateTime? DateOrderBegin { get; set; }

    public DateTime? DateOrderEnd { get; set; }

    public int? StatusId { get; set; }

    public int? UserId { get; set; }
    public int? PaymentId { get; set; }
    public string? Comment { get; set; }

    public virtual ICollection<OrderedProduct> OrderedProducts { get; set; } = new List<OrderedProduct>();
    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual Status? Status { get; set; }
    [JsonIgnore]

    public virtual User? User { get; set; }
}
