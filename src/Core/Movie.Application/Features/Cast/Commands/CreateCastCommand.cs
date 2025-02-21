using MediatR;
using Movie.Application.Common.Base;

namespace Movie.Application.Features.Cast.Commands
{
    public sealed class CreateCastCommand : IRequest<BaseResponse>
    {
        public string Title { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public string? Overview { get; set; }
        public string? Biography { get; set; }
    }
}
