using Client.DataService.DboModels;
using Client.DataService.SpecialModels;
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

        public ProfileViewModel()
        {
            ApperingCommand = new Command((object args) => Init());
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
         
        }
    }
}
