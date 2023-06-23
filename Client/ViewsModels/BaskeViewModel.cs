using Client.DataService;
using Client.DataService.DboModels;
using Client.Views.OrdersViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewsModels
{
    public class BaskeViewModel : BaseVM
    {
	    public ObservableCollection<Basket> Baskets { get; set; }
        public Command ApperingCommand { get; set; }
        public Command OutFromAccount { get; set; }


        private double _SumOrder;

        public double SumOrder
        {
            get { return _SumOrder; }
            set { _SumOrder = value;
                OnPropertyChanged();
            }
        }
        public Command PlusCommand { get; set; }
        public Command MinusCommand { get; set; }
        public Command DeleteCommand { get; set; }

        public BaskeViewModel()
        {
            Baskets = new ObservableCollection<Basket>();
            ApperingCommand = new Command((object args) => Init());
            PlusCommand = new Command((object args) => Plus(args as Basket));
            MinusCommand = new Command((object args) => Minus(args as Basket));
            DeleteCommand = new Command((object args) => Delete(args as Basket));
            OutFromAccount = new Command((object args) => OutAccount());

        }
        public async void Init()
        {
            SumOrder = 0;
            List<Basket> baskets = await restAPIService.GetUserBasketById();
            Baskets.Clear();
            foreach(var item in baskets)
            {
                Baskets.Add(item);
                SumOrder = (double)(SumOrder + item.Product.ProductPrice * item.CountProduct);
            }
            SumOrder = Math.Round(SumOrder, 2);


        }

        public async void GoToOrderCreatePage()
        {
            if(Baskets.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(Preferences.Default.Get("Login", "")))
                {
                    await Shell.Current.Navigation.PushAsync(new OrderCreateView());
                }
                else
                {
                    NeedAuthorized();
                }
            }
            else
            {
                await Shell.Current.DisplayAlert(" ", "Корзина пуста", "Ок");
            }
        }
        public async void Plus(Basket basket)
        {
            await restAPIService.UpdateCountProductInBasket(basket, "plus");
            basket.CountProduct = basket.CountProduct + 1;
            SumOrder = (double)(SumOrder + basket.Product.ProductPrice);
            SumOrder = Math.Round(SumOrder, 2);
        }
        public async void OutAccount()
        {
            bool answer = await Shell.Current.DisplayAlert("Выход из аккаунта", "Вы действительно хотите выйти из аккаунта?", "Да", "Нет");
            if (answer)
            {
                Preferences.Default.Clear();
                StaticValues.Favorites.Clear();
                StaticValues.Basket.Clear();
                Init();
            }

        }
        public async void Minus(Basket basket)
        {
            string result = await restAPIService.UpdateCountProductInBasket(basket, "gdsgdsg");
            if (result == "MinusAction")
            {
                basket.CountProduct = basket.CountProduct - 1;
                SumOrder = (double)(SumOrder - basket.Product.ProductPrice);
                SumOrder = Math.Round(SumOrder, 2);
            }
            else
            {
                Baskets.Remove(basket);
                StaticValues.Basket.Remove(basket);
                SumOrder = (double)(SumOrder - basket.Product.ProductPrice * basket.CountProduct);
                SumOrder = Math.Round(SumOrder, 2);
            }
          

        }
        public async void Delete(Basket basket)
        {
            await restAPIService.DeleteProductFromBasket(basket);
            Baskets.Remove(basket);
            StaticValues.Basket.Remove(basket);
            SumOrder = (double)(SumOrder - basket.Product.ProductPrice * basket.CountProduct);
            SumOrder = Math.Round(SumOrder, 2);


        }
    }
}
