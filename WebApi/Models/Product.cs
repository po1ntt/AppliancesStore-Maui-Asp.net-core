using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? ProductName { get; set; }

    public string? ProductDescription { get; set; }

    public int? ProductCategoryId { get; set; }
    public double? ProductPrice { get; set; }
    public int? ProductBrandId { get; set; }
    [NotMapped]
    public double AvgGrade { get; set; }
    [NotMapped]
    public double CountReviews { get; set; }
    public string? ProductImage { get; set; }
    [JsonIgnore]

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();
    [JsonIgnore]

    public virtual ICollection<OrderedProduct> OrderedProducts { get; set; } = new List<OrderedProduct>();

    public virtual Brand? ProductBrand { get; set; }

    public virtual Category? ProductCategory { get; set; }
    [JsonIgnore]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
