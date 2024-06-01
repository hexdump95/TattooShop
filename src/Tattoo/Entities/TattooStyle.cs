using System.ComponentModel.DataAnnotations;

namespace Tattoo.Entities
{
    public class TattooStyle
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
    }
}
