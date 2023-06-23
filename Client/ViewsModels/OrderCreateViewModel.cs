using Client.DataService;
using Client.DataService.DboModels;
using Mopups.Services;
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
        public Command CreateOrder { get; set; }

        public OrderCreateViewModel()
        {
            CreateOrder = new Command(async (object args) => await AddOrder());
            Init();
        }
        public async Task AddOrder()
        {
            try
            {
               
                IsBusy = true;
                ShowLoadingPopup();
                if (!string.IsNullOrWhiteSpace(FirstName)
            && !string.IsNullOrWhiteSpace(SecondName)
            && !string.IsNullOrWhiteSpace(Patronymic)
            && !string.IsNullOrWhiteSpace(Adres)
            && SelectedPaymentMethod != null)
                {
                    List<Basket> baskets = await restAPIService.GetUserBasketById();
                    Random random = new Random();
                    Order order = new Order();
                    order.FirstNameReceiver = FirstName;
                    order.SecondNameReceiver = SecondName;
                    order.AdressReceiver = Adres;
                    order.Comment = Comment;
                    order.PatronymicReceiver = Patronymic;
                    order.StatusId = 1;
                    order.PaymentId = SelectedPaymentMethod.IdPayment;
                    order.OrderNumber = random.Next(999, 1000000).ToString();
                    order.UserId = Preferences.Default.Get("id_user", 0);
                    foreach (var item in baskets)
                    {
                        order.OrderedProducts.Add(new OrderedProduct()
                        {
                            ProductId = item.ProductId,
                            CountProduct = item.CountProduct
                        });
                    }
                    bool result = await restAPIService.AddNewOrder(order);
                    if (result)
                    {
                        ShowSnackBar("Заказ успешно создан");
                        foreach(var item in baskets)
                        {
                            await restAPIService.DeleteProductFromBasket(item);
                        }
                        StaticValues.Basket.Clear();
                        await Shell.Current.Navigation.PopAsync();

                    }
                    else
                    {
                        ShowSnackBar("SomethingGoingWrong");

                    }

                }
                else
                {
                    await Shell.Current.DisplayAlert("", "Заполните данные для заказа", "Ок");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "ок");
                throw;
            }
            finally
            {
                IsBusy = false;
                await MopupService.Instance.PopAsync();
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
                SumOrder = (double)(SumOrder + item.Product.ProductPrice * item.CountProduct);

            }
            SumOrder = Math.Round(SumOrder, 2);

        }
    }
}
