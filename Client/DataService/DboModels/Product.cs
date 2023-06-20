using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Client.DataService.DboModels;

public partial class Product : INotifyPropertyChanged
{
    public int IdProduct { get; set; }

    public string? ProductName { get; set; }

    public string? ProductDescription { get; set; }

    public int? ProductCategoryId { get; set; }
    public double? ProductPrice { get; set; }

    public double AvgGrade { get; set; }
    public double CountReviews { get; set; }
    public int? ProductBrandId { get; set; }
    private string _IsFavorite;

    public string IsFavorite
    {
        get { return _IsFavorite; }
        set { _IsFavorite = value;
            OnPropertyChanged();
        }
    }
    private string _IsBasket;

    public string IsBasket
    {
        get { return _IsBasket; }
        set { _IsBasket = value;
            OnPropertyChanged();
        }
    }

    public string? ProductImage { get; set; }
    [JsonIgnore]

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();
    [JsonIgnore]

    public virtual ICollection<OrderedProduct> OrderedProducts { get; set; } = new List<OrderedProduct>();
    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();


    public virtual Brand? ProductBrand { get; set; }

    public virtual Category? ProductCategory { get; set; }
    [JsonIgnore]

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
    public event PropertyChangedEventHandler PropertyChanged;
}
