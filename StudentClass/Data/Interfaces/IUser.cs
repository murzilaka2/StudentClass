using StudentClass.Data.Models;
using System.Security.Claims;

namespace StudentClass.Data.Interfaces
{
    public interface IUser
    {
        IEnumerable<User> Users { get; }
        User GetById(int id);
        ClaimsIdentity getClaims(ViewModels.UserPass.LoginViewModel loginViewModel);
    }
}
