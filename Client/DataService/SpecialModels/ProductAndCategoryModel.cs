using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Client.DataService.DboModels;

namespace Client.DataService.SpecialModels
{
    public class ProductAndCategoryModel : INotifyPropertyChanged
    {
        public string? nameCategory { get; set; }

        private List<Product> _products = new List<Product>();

        public List<Product> products
        {
            get { return _products; }
            set {
                _products = value;
                OnPropertyChanged();
            } 
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
