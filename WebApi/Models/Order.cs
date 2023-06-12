using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public string? OrderNumber { get; set; }

    public int? OrderedProductsId { get; set; }

    public DateTime? DateOrderBegin { get; set; }

    public DateTime? DateOrderEnd { get; set; }

    public int? StatusId { get; set; }

    public int? UserId { get; set; }

    public string? Comment { get; set; }
    [JsonIgnore]

    public virtual OrderedProduct? OrderedProducts { get; set; }
    [JsonIgnore]

    public virtual Status? Status { get; set; }
    [JsonIgnore]

    public virtual User? User { get; set; }
}
