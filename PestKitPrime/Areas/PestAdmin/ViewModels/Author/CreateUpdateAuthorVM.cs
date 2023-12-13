using System.ComponentModel.DataAnnotations;

namespace PestKitPrime.Areas.PestAdmin.ViewModels
{
    public class CreateUpdateAuthorVM
    {
        [Required(ErrorMessage = "Name can not be empty!")]
        [MaxLength(25, ErrorMessage = "Name should be `1-25 letters long.")]
        public string Name { get; set; }
    }
}
