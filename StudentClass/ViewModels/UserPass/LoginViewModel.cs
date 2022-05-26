using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StudentClass.ViewModels.UserPass
{
    public class LoginViewModel
    {
        [Remote(action: "IsEmailExist",controller: "Home", ErrorMessage = "Email is not exist!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email not valid!")]
        [Required(ErrorMessage = "Error: email is not set!")]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Error: password is not set!")]
        public string? Pass { get; set; }
    }
}
