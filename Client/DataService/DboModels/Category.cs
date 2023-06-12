using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Client.DataService.DboModels;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? Name { get; set; }
    public string? Logo { get; set; }

    [JsonIgnore]

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
