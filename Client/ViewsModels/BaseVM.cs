using Client.DataService;
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
        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
        }
        public BaseVM()
        {
            if(Preferences.Default.Get("phone", string.Empty) != string.Empty)
            {
                UsersService.usersService.AuthorizeUser(new Models.Users() 
                {
                    userPhone = Preferences.Default.Get("phone", string.Empty),
                    userPasswod = Preferences.Default.Get("password", string.Empty) 
                });
            }
            CheckUserAuth();
        }
        public void CheckUserAuth()
        {
            if (UsersService.UserInfo != null)
            {
                IsNotUserAuth = false;
            }
            else
            {
                IsNotUserAuth = true;
            }
        }

    }
}
