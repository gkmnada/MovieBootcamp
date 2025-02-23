using MediatR;
using Movie.Application.Common.Base;

namespace Movie.Application.Features.Category.Commands
{
    public sealed class CreateCategoryCommand : IRequest<BaseResponse>
    {
        public string Name { get; set; } = string.Empty;
    }
}
