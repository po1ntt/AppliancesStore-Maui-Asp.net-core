using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Client.DataService.DboModels;

public partial class Brand
{
    public int IdBrand { get; set; }

    public string? NameBrand { get; set; }

    public string? LogoBrand { get; set; }
    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
