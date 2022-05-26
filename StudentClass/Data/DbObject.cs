using StudentClass.Data.Models;

namespace StudentClass.Data
{
    public class DbObjects
    {
        public static void Initial(ApplicationContext applicationContext)
        {
            if (!applicationContext.Users.Any())
            {
                User user = new User
                {
                    Email = "alex@gmail.com",
                    FirstName = "Alex",
                    LastName = "Smith",
                    HashPassword = "wewtX7WjIUj4kB7DtADUFHoWFpX1RPnRG1FCs9g4RlDyx7KjpdBo0tgWn/LuftkT50nJG0jKBdIgzjAQo6JbFYS9MuNnjA==",
                    Salt = "4PpUEWDGS7HhOQvFtcqBqb1XvFP06FKLkh+GGKIDhFt0MuXUmPT8B0gNIK7LRqMBR9JkcvWAikpMsZB3iSKbB5oFMEwRMQ=="//qwerty
                };
                applicationContext.Users.Add(user);
                applicationContext.SaveChanges();
            }
        }
    }
}
