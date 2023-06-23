using Client.DataService.DboModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewsModels
{
	

	public class OrdersAboutViewModel : BaseVM
    {
        private Order _Order;

        public Order Order
        {
            get { return _Order; }
            set
            {
                _Order = value;
                OnPropertyChanged();
            }
        }
        private double _SumOrder = 0;

        public double SumOrder
        {
            get { return _SumOrder; }
            set { _SumOrder = value;
                OnPropertyChanged();
            }
        }
        public Command DeleteOrder { get; set; }
        public OrdersAboutViewModel(Order order)
        {
            Order = order;
            DeleteOrder = new Command((object args) => CancelOrder());
            GetSumOrder();
        }
        public async void CancelOrder()
        {
            bool result = await restAPIService.DeletOrder(Order.IdOrder);
            if (result)
            {
                await Shell.Current.Navigation.PopAsync();
                ShowSnackBar("Заказ отменен");
            }
            else
            {
                ShowSnackBar("Ошибочка...");
            }
        }
        public void GetSumOrder()
        {
            foreach(var item in Order.OrderedProducts)
            {
                SumOrder = (double)(SumOrder + item.Product.ProductPrice * item.CountProduct);
            }
            SumOrder = Math.Round(SumOrder, 2);

        }
    }
}
