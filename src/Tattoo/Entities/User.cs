using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tattoo.Entities
{
    public class User
    {
        [MaxLength(50)] 
        public string Id { get; set; }
        [Column] 
        [MaxLength(25)] 
        public string Username { get; set; }
        [Column] 
        [MaxLength(25)] 
        public string Password { get; set; }
        [Column] 
        [MaxLength(50)] 
        public string Email { get; set; }

        public List<UserRole> UserRoles { get; set; } = [];
    }
}
