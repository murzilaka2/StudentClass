using System.ComponentModel.DataAnnotations;

namespace StudentClass.Data.Models
{
    public class UserRoles
    {
        public User User { get; set; }
        public Role Role { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
