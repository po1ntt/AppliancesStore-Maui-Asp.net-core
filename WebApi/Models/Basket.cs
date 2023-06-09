﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.Models;

public partial class Basket
{
    public int IdBasket { get; set; }

    public int? ProductId { get; set; }

    public int? UserId { get; set; }
    public int? CountProduct { get; set; }
    public virtual Product? Product { get; set; }
    [JsonIgnore]

    public virtual User? User { get; set; }
}
