using System.ComponentModel.DataAnnotations;

namespace CrudApplication.Models.Auth
{
    public class AuthModel
    {

    }

    public class UserLoginModel
    {
        [Required(ErrorMessage = "Username field is required.")]
        [MaxLength(10)]
        [MinLength(5)]
        public string? Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
