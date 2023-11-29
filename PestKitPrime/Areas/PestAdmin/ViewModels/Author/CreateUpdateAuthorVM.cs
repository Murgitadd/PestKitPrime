using System.ComponentModel.DataAnnotations;

namespace PestKitPrime.Areas.PestAdmin.ViewModels
{
    public class CreateUpdateAuthorVM
    {
        [Required(ErrorMessage = "Name must be entered mutled")]
        [MaxLength(25, ErrorMessage = "It should not exceed 25 characters")]
        public string Name { get; set; }
    }
}
