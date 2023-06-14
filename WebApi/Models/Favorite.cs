using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.Models;

public partial class Favorite
{
   
    public int IdFavorites { get; set; }

    public int? ProductId { get; set; }

    public int? UserId { get; set; }
    [JsonIgnore]

    public virtual User? User { get; set; }

    [JsonIgnore]

    public virtual Product? Product { get; set; }
}
