using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Views.Templates.ProductsTemplate
{
    public partial  class ProductModel : ObservableObject
    {
        [ObservableProperty]
        private Products productData;
        public ReviewsProduct Reviews;
        [ObservableProperty]
        private bool isFavorite;
        [ObservableProperty]
        private double avgGrade;
        [ObservableProperty]
        private bool isInBasket;
        [RelayCommand]
        private async Task addRemoveForFavaoriteAsync()
        {

        }
        [RelayCommand]
        private async Task addOrRemoveFromToBasketAsync()
        {

        }

    }
}
