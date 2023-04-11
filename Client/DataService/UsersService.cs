using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.DataService
{
    public class UsersService : BaseService
    {
        public static Users UserInfo { get; set; }
        public static CategoryService categoryService = new CategoryService();
        public async Task<Users> GetuserInfo(string phone, string password)
        {
            Users Users = new();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Console.WriteLine("504");
                return Users;
            }
            try
            {

                HttpResponseMessage response = await httpclient.GetAsync($"{Adress}/api/Users/GetUserByData?phone={phone}&password={password}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    Users = JsonSerializer.Deserialize<Users>(data, jsonSerializerOptions);
                    if(Users != null)
                    {
                        AuthorizeUser(Users);
                    }
                }
                else
                {
                    Console.WriteLine("202");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Users;
            }
            return Users;
        }
      
        public void AuthorizeUser(Users users)
        {
            UserInfo = users;
            Preferences.Default.Set("phone", users.userPhone);
            Preferences.Default.Set("password", users.userPasswod);
        }
    }
}
