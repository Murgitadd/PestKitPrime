namespace PestKitPrime.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Employee>? Emoloyees { get; set; }
    }
}
