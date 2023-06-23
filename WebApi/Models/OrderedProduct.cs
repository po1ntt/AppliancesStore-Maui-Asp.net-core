using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.Models;

public partial class OrderedProduct
{
    public int IdOrderedProducts { get; set; }

    public int? orderId { get; set; }

    public int? CountProduct { get; set; }
    public int? ProductId { get; set; }

    [JsonIgnore]

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }

}
