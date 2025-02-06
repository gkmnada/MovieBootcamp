namespace Movie.Domain.Entities
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public bool Status { get; set; } = true;
    }
}