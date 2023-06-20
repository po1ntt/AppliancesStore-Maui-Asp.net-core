using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Client.DataService.DboModels;

public partial class Basket : INotifyPropertyChanged
{
    public int IdBasket { get; set; }

    public int ProductId { get; set; }

    public int UserId { get; set; }
    private int _CountProduct;

    public int CountProduct
    {
        get { return _CountProduct; }
        set { _CountProduct = value;
            OnPropertyChanged();
        }
    }


    public virtual Product? Product { get; set; }
    [JsonIgnore]

    public virtual User? User { get; set; }
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
    public event PropertyChangedEventHandler PropertyChanged;
}
