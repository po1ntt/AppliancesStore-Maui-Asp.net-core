using Client.DataService;
using Client.DataService.ServiceAPI;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Mopups.Interfaces;
using Mopups.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewsModels
{
    public class BaseVM : INotifyPropertyChanged
    {
        public IPopupNavigation popupNavigation;

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
        public NetworkAccess networkAccess { get; set; }
        public IRestAPIService restAPIService { get; set; }
        public BaseVM()
        {
            popupNavigation = new PopupNavigation();
            restAPIService = new RestAPIService();
            networkAccess = Connectivity.NetworkAccess;
        }
        public async void ShowSnackBar(string message)
        {
            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Colors.Orange,
                TextColor = Colors.White,
                ActionButtonTextColor = Colors.White,
                CornerRadius = new CornerRadius(5),
                CharacterSpacing = 0


            };
            TimeSpan duration = TimeSpan.FromSeconds(2);
            var snacbarTest = Snackbar.Make(message, duration: duration, actionButtonText: "Ок", visualOptions: snackbarOptions);


            await snacbarTest.Show();
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
