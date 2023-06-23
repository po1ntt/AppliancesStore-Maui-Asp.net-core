using Client.DataService.DboModels;
using Client.DataService.SpecialModels;
using Client.Views.OrdersViews;
using Mopups.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewsModels
{
    public class ProfileViewModel : BaseVM
    {
       
        public ObservableCollection<SpecialOrder> SpecialOrders { get; set; } = new ObservableCollection<SpecialOrder>();
        public Command ApperingCommand { get; set; }

        public Command OpenOrder { get; set; }
        public Command OutFromAccount { get; set; }

        public ProfileViewModel()
        {
            ApperingCommand = new Command((object args) => Init());
            OpenOrder = new Command((object args) => GoToAboutOrder(args as Order));
        }
        public async void GoToAboutOrder(Order order)
        {
            IsBusy = true;
            ShowLoadingPopup();

            await Shell.Current.Navigation.PushAsync(new OrderAboutView(order));


            IsBusy = false;
            await MopupService.Instance.PopAsync();


        }
        public async void Init()
        {
            List<Order> orders = new List<Order>();
            orders = await restAPIService.GetOrders();
            var listActiveOrders = orders.Where(p => p.StatusId != 4).ToList();
            var listNotActiveOrders = orders.Where(p => p.StatusId == 4).ToList();
            SpecialOrders.Clear();
            if (listActiveOrders.Count() != 0)
            {
                SpecialOrders.Add(new SpecialOrder()
                {
                    Name = "Активные заказы"
                    , Orders = listActiveOrders.ToList()
                });
            }
            if (listNotActiveOrders.Count() != 0)
            {
                SpecialOrders.Add(new SpecialOrder()
                {
                    Name = "Завершенные заказы",
                    Orders = listNotActiveOrders.ToList()
                });
            }
            OutFromAccount = new Command((object args) => OutAccount());


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
    }
}
