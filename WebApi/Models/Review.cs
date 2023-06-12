using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.Models;

public partial class Review
{
    public int IdReviews { get; set; }

    public int? ProductId { get; set; }

    public int? UserId { get; set; }

    public string? Review1 { get; set; }

    public double Grade { get; set; }
    [JsonIgnore]

    public virtual Product? Product { get; set; }
    [JsonIgnore]

    public virtual User? User { get; set; }
}
