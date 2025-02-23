using MediatR;
using Movie.Application.Common.Base;

namespace Movie.Application.Features.Category.Commands
{
    public sealed class DeleteCategoryCommand : IRequest<BaseResponse>
    {
        public int CategoryID { get; set; }

        public DeleteCategoryCommand(int id)
        {
            CategoryID = id;
        }
    }
}
