using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewsModels
{
    public class BaseVM : ObservableObject
    {
		private bool _IsNotUserAuth;

		public bool IsNotUserAuth
        {
			get { return _IsNotUserAuth; }
			set { _IsNotUserAuth = value;
				OnPropertyChanged();
			}
		}
        public BaseVM()
        {
            IsNotUserAuth = true;
        }

    }
}
