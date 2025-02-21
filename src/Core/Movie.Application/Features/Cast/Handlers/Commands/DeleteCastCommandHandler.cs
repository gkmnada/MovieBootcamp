using MediatR;
using Microsoft.Extensions.Logging;
using Movie.Application.Common.Base;
using Movie.Application.Features.Cast.Commands;
using Movie.Application.Interfaces.Repositories;

namespace Movie.Application.Features.Cast.Handlers.Commands
{
    public sealed class DeleteCastCommandHandler : IRequestHandler<DeleteCastCommand, BaseResponse>
    {
        private readonly ICastRepository _castRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteCastCommandHandler> _logger;

        public DeleteCastCommandHandler(ICastRepository castRepository, IUnitOfWork unitOfWork, ILogger<DeleteCastCommandHandler> logger)
        {
            _castRepository = castRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<BaseResponse> Handle(DeleteCastCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var values = await _castRepository.GetByIdAsync(request.CastID, cancellationToken);

                if (values == null)
                {
                    return new BaseResponse
                    {
                        IsSuccess = false,
                        Message = "Cast not found"
                    };
                }

                await _castRepository.DeleteAsync(values);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new BaseResponse
                {
                    Data = values,
                    Message = "Cast deleted successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the cast");
                throw new Exception("An error occurred while deleting the cast", ex);
            }
        }
    }
}
