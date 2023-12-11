using System.ComponentModel.DataAnnotations;

namespace PestKitPrime.ViewModels.Account
{
    public class RegisterVM
    {
        [Required]
        [MaxLength(25)]
        [MinLength(5)]
        public string Surname { get; set; }
        [Required]
        [MaxLength (25)]
        [MinLength (5)]
        public string Name { get; set; }
        [Required]
        [MinLength(5)]
        public string Username { get; set; }
        [Required]
        [MinLength (8)]
        [DataType (DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
