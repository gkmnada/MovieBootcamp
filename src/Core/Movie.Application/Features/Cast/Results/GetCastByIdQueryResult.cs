namespace Movie.Application.Features.Cast.Results
{
    public sealed class GetCastByIdQueryResult
    {
        public int CastID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public string? Overview { get; set; }
        public string? Biography { get; set; }
        public bool IsActive { get; set; }
    }
}
