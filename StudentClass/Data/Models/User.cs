using System.Collections.Generic;

namespace StudentClass.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public string Salt { get; set; }
        public IEnumerable<UserRoles> UserRoles { get; set; }
    }
}
