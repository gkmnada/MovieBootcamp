using MediatR;
using Movie.Application.Common.Base;

namespace Movie.Application.Features.Category.Commands
{
    public sealed class UpdateCategoryCommand : IRequest<BaseResponse>
    {
        public int CategoryID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
