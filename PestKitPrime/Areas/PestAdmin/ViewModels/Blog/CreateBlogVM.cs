using PestKitPrime.Models;
using System.ComponentModel.DataAnnotations;

namespace PestKitPrime.Areas.PestAdmin.ViewModels
{
    public class CreateBlogVM
    {
        [Required(ErrorMessage = "Title can not be empty!")]
        [MaxLength(50, ErrorMessage = "Title should be `1-50 letters long.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description can not be empty!")]
        [MaxLength(100, ErrorMessage = "Title should be `1-100 letters long.")]
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "There can not be no authors.")]
        public int? AuthorId { get; set; }
        [Required]
        public int CommentCount { get; set; }

    }
}
