using System.ComponentModel.DataAnnotations;

namespace PestKitPrime.Areas.PestAdmin.ViewModels
{
    public class UpdateBlogVM
    {
        [Required(ErrorMessage = "Title can not be empty!")]
        [MaxLength(25, ErrorMessage = "Title should be `1-25 letters long.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description can not be empty")]
        [MaxLength(100, ErrorMessage = "Title should be `1-100 letters long.")]
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public IFormFile? Photo { get; set; }
        public string ImgUrl { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "There can not be no authors.")]
        public int? AuthorId { get; set; }
        [Required]
        public int CommentCount { get; set; }
    }
}
