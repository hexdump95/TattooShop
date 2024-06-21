using System.ComponentModel.DataAnnotations;

namespace Tattoo.Entities
{
    public class Tattooer
    {
        public long Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public int Age { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
    }
}
