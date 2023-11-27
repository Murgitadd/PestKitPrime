namespace PestKitPrime.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
