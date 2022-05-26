using StudentClass.Data.Helpers;
using StudentClass.Data.Interfaces;
using StudentClass.Data.Models;
using StudentClass.ViewModels.UserPass;
using System.Security.Claims;

namespace StudentClass.Data.Repository
{
    public class UserRepository : IUser
    {
        private readonly ApplicationContext context;
        public UserRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> Users => context.Users;

        public User GetById(int id) => context.Users.FirstOrDefault(u => u.Id == id);

        public ClaimsIdentity getClaims(LoginViewModel loginViewModel)
        {
            var currentUser = context.Users.FirstOrDefault(x=>x.Email.ToLower().Equals(loginViewModel.Email.ToLower()));
            if (currentUser != null)
            {
                String heshPassword = SecurityHelper.HashPassword(loginViewModel.Pass, currentUser.Salt, 10101, 70);
                if(heshPassword.Equals(currentUser.HashPassword))
                {
                    var claims = new List<Claim> { new Claim("Id", currentUser.Id.ToString()) };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,"Cookies");
                    return claimsIdentity;
                }
            }
           
            return null;
        }


    }
}
