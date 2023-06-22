using Client.DataService.DboModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DataService.SpecialModels
{
    public class SpecialOrder
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
