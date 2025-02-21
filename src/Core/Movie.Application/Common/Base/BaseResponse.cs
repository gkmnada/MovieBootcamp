namespace Movie.Application.Common.Base
{
    public class BaseResponse
    {
        public object Data { get; set; } = null!;
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public ICollection<string> Errors { get; set; } = new List<string>();
    }
}
