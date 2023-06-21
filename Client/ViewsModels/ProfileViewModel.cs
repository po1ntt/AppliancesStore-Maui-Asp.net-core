using Client.DataService.DboModels;
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
        public ObservableCollection<Order> ActiveOrders { get; set; } = new ObservableCollection<Order>();
        public ObservableCollection<Order> EndedOrders { get; set; } = new ObservableCollection<Order>();
    }
}
