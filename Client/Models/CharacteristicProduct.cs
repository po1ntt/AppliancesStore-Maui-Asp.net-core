using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models
{
    public class CharacteristicProduct
    {
        public int id_characteristProduct { get; set; }
        public int character_id { get; set; }
        public string characterValue { get; set; }
        public int product_id { get; set; }
        public Character character { get; set; }
    }
}
