using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.Models;

public partial class Status
{
    public int IdStatus { get; set; }

    public string? Status1 { get; set; }
    [JsonIgnore]

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
