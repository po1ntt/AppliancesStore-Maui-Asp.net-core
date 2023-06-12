using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.Models;

public partial class Adrese
{
    public int IdAdress { get; set; }

    public string? Adress { get; set; }

    public int? UserId { get; set; }
    [JsonIgnore]

    public virtual User? User { get; set; }
}
