namespace Movie.Domain.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}