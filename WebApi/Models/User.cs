using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApi.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? Gender { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? Patronymic { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }
    [JsonIgnore]
    public virtual ICollection<Adrese> Adreses { get; set; } = new List<Adrese>();
    [JsonIgnore]


    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();
    [JsonIgnore]

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    [JsonIgnore]

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    [JsonIgnore]

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    [JsonIgnore]

    public virtual Role? Role { get; set; }
}
