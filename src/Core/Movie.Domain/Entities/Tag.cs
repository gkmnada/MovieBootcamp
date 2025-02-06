namespace Movie.Domain.Entities
{
    public class Tag
    {
        public int TagID { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}