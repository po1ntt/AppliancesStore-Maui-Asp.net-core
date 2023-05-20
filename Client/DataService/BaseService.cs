using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.DataService
    {
    public class BaseService
    {
        public HttpClient httpclient;
        public readonly string Adress;
        public readonly JsonSerializerOptions jsonSerializerOptions;

        public BaseService()
        {
            httpclient = new HttpClient();
            Adress = DeviceInfo.Platform == DevicePlatform.Android ? "http://192.168.0.114:5067" : "http://192.168.0.114:5067";
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
    }
}
