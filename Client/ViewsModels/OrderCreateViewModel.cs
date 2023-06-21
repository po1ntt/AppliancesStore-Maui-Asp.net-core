using Client.DataService.DboModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewsModels
{
    public class OrderCreateViewModel : BaseVM
    {
        private string _Comment;

        public string Comment
        {
            get { return _Comment; }
            set { _Comment = value;
                OnPropertyChanged();
            }
        }

        private string _Adres;

        public string Adres
        {
            get { return _Adres; }
            set { _Adres = value;
                OnPropertyChanged();
            }
        }


        private double _SumOrder;

        public double SumOrder
        {
            get { return _SumOrder; }
            set
            {
                _SumOrder = value;
                OnPropertyChanged();
            }
        }
        private string _FirstName;

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value;
                OnPropertyChanged();
            }
        }
        private string _SecondName;

        public string SecondName
        {
            get { return _SecondName; }
            set
            {
                _SecondName = value;
                OnPropertyChanged();
            }
        }
        private string _Patronymic;

        public string Patronymic
        {
            get { return _Patronymic; }
            set
            {
                _Patronymic = value;
                OnPropertyChanged();
            }
        }
        private PaymentMethod _SelectedPaymentMethod;

        public PaymentMethod SelectedPaymentMethod
        {
            get { return _SelectedPaymentMethod; }
            set
            {
                _SelectedPaymentMethod = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PaymentMethod> PaymentMethods { get; set; } = new ObservableCollection<PaymentMethod>();
        public ObservableCollection<Basket> Baskets {get;set;} = new ObservableCollection<Basket>();

        public OrderCreateViewModel()
        {
            Init();
        }
        public async void AddOrder()
        {
           if(!string.IsNullOrWhiteSpace(FirstName)
             && !string.IsNullOrWhiteSpace(SecondName)
             && !string.IsNullOrWhiteSpace(Patronymic)
             && !string.IsNullOrWhiteSpace(Adres)
             && SelectedPaymentMethod != null)
            {

            }
            else
            {
                await Shell.Current.DisplayAlert("", "Заполните данные для заказа", "Ок");
            }
        }
        public async void Init()
        {
            SumOrder = 0;

            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();
            paymentMethods = await restAPIService.GetPaymentMethods();
            PaymentMethods.Clear();
            foreach(var item in paymentMethods)
            {
                PaymentMethods.Add(item);
            }
            List<Basket> baskets = new List<Basket>();
            baskets = await restAPIService.GetUserBasketById();
            Baskets.Clear();
            foreach (var item in baskets)
            {
                Baskets.Add(item);
                SumOrder = (double)(SumOrder + item.Product.ProductPrice);

            }
            SumOrder = Math.Round(SumOrder, 2);

        }
    }
}
