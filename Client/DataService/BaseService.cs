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
            Adress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5067" : "https://localhost:7202";
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
    }
}
