using Client.DataService.DboModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.DataService.SpecialModels
{
    public class SpecialOrder : INotifyPropertyChanged
    {
        public string Name { get; set; }

        private List<Order> _Orders = new List<Order>();

        public List<Order> Orders
        {
            get { return _Orders; }
            set { _Orders = value;
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
