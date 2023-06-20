using Client.DataService.DboModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.DataService
{
    public static class StaticValues
    {

        public static List<Product> Favorites { get
        ;set; }
        public static List<Basket> Basket
        {
            get
        ; set;
        }

    }
}
