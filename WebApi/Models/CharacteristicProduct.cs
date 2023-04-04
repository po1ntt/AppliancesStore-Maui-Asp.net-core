using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class CharacteristicProduct
    {
        [Key]
        public int id_characteristProduct { get; set; }
        [ForeignKey("Character")]
        public int character_id { get; set; }
        public string? CharacterValue { get; set; }
        [ForeignKey("Products")]
        public int product_id { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Products? Product { get; set; }
        public Character? Character { get; set; }

    }
}
