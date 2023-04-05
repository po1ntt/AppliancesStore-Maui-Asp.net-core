using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.DataService
{
    public class ImageService : BaseService
    {
        public static ImageService imageService = new ImageService();

        public async Task<Byte[]> GetImageByte(string namelink)
        {
            Byte[] result = new Byte[7000];
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Console.WriteLine("504");
                return null;
            }
            try
            {

                HttpResponseMessage response = await httpclient.GetAsync($"{Adress}/api/Images?name={namelink}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<Byte[]>(data, jsonSerializerOptions);
                }
                else
                {
                    Console.WriteLine("202");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return result;
        }
    }
}
