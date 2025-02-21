using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Movie.Application.Common.Base;
using Movie.Application.Features.Cast.Commands;
using Movie.Application.Features.Cast.Validators;
using Movie.Application.Interfaces.Repositories;

namespace Movie.Application.Features.Cast.Handlers.Commands
{
    public sealed class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand, BaseResponse>
    {
        private readonly ICastRepository _castRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCastCommandHandler> _logger;
        private readonly UpdateCastValidator _validator;

        public UpdateCastCommandHandler(ICastRepository castRepository, IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateCastCommandHandler> logger, UpdateCastValidator validator)
        {
            _castRepository = castRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        public async Task<BaseResponse> Handle(UpdateCastCommand request, CancellationToken cancellationToken)
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

                var validationResult = await _validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

                    return new BaseResponse
                    {
                        IsSuccess = false,
                        Message = "Validation failed",
                        Errors = errors
                    };
                }

                var cast = _mapper.Map(request, values);

                await _castRepository.UpdateAsync(cast);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new BaseResponse
                {
                    Data = values,
                    Message = "Cast updated successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred on updating cast");
                throw new Exception("An error occurred on updating cast", ex);
            }
        }
    }
}
