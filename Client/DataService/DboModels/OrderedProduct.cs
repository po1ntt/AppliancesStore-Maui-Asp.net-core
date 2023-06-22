using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Client.DataService.DboModels;

public partial class OrderedProduct
{
    public int IdOrderedProducts { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }
    public int? CountProduct { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    [JsonIgnore]

    public virtual Product? Product { get; set; }
    [JsonIgnore]

    public virtual User? User { get; set; }
}
