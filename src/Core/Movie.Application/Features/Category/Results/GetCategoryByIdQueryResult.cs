namespace Movie.Application.Features.Category.Results
{
    public sealed class GetCategoryByIdQueryResult
    {
        public int CategoryID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
