using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Movie.Application.Common.Base;
using Movie.Application.Features.Cast.Commands;
using Movie.Application.Features.Cast.Validators;
using Movie.Application.Interfaces.Repositories;

namespace Movie.Application.Features.Cast.Handlers.Commands
{
    public sealed class CreateCastCommandHandler : IRequestHandler<CreateCastCommand, BaseResponse>
    {
        private readonly ICastRepository _castRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCastCommandHandler> _logger;
        private readonly CreateCastValidator _validator;

        public CreateCastCommandHandler(ICastRepository castRepository, IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateCastCommandHandler> logger, CreateCastValidator validator)
        {
            _castRepository = castRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        public async Task<BaseResponse> Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            try
            {
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

                var entity = _mapper.Map<Domain.Entities.Cast>(request);

                await _castRepository.CreateAsync(entity);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new BaseResponse
                {
                    Data = entity,
                    Message = "Cast created successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the cast");
                throw new Exception("An error occurred while creating the cast", ex);
            }
        }
    }
}
