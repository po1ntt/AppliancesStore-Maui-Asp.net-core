using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewsModels
{
    public partial class ProductsVM : ObservableObject

    {
        [ObservableProperty]  
        private List<Products> productsList;

        [RelayCommand]
        private async Task addToFavaoriteAsync()
        {

        }
        [RelayCommand]
        private async Task addToBasketAsync()
        {

        }
    }
}
