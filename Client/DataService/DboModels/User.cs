using System;
using System.Collections.Generic;

namespace Client.DataService.DboModels;

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

    public virtual ICollection<Adrese> Adreses { get; set; } = new List<Adrese>();

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();


    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Role? Role { get; set; }
}
