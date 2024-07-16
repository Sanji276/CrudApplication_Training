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

    public class UserSignupModel
    {
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }        
        public int ContactNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password) ,ErrorMessage ="Password didn't match")]
        public string? ConfirmPassword { get; set; }
    }
}
