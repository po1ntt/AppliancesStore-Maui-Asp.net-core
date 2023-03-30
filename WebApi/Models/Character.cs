using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Character
    {
        [Key]
        public int id_character { get; set; }
        public string? CharacterName { get; set; }
    }
}
