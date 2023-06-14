using Client.DataService.DboModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewsModels
{
    public class FavoritesViewModel : BaseVM
    {
		
        public FavoritesViewModel()
        {
                
        }

      /*  public async void Init()
        {
			try
			{
				if (!string.IsNullOrWhiteSpace(Preferences.Get("Login", "")))
                {
                    Favorites = await restAPIService.GetUserFavorites(Preferences.Get("Login", ""), Preferences.Get("Password", ""));
                }
            }
			catch (Exception)
			{

				throw;
			}
        }*/

    }
}
