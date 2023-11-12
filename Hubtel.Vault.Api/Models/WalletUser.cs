using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Hubtel.Vault.Api.Models
{
    public class WalletUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }   

    }

    public class SignUpModel 
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }    
    }

    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        
    }
}
