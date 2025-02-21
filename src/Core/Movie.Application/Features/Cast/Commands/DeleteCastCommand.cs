using MediatR;
using Movie.Application.Common.Base;

namespace Movie.Application.Features.Cast.Commands
{
    public sealed class DeleteCastCommand : IRequest<BaseResponse>
    {
        public int CastID { get; set; }

        public DeleteCastCommand(int id)
        {
            CastID = id;
        }
    }
}
