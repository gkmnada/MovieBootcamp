using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Movie.Application.Common.Base;
using Movie.Application.Features.Category.Commands;
using Movie.Application.Features.Category.Validators;
using Movie.Application.Interfaces.Repositories;

namespace Movie.Application.Features.Category.Handlers.Commands
{
    public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCategoryCommandHandler> _logger;
        private readonly UpdateCategoryValidator _validator;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateCategoryCommandHandler> logger, UpdateCategoryValidator validator)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
        }

        public async Task<BaseResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var values = await _categoryRepository.GetByIdAsync(request.CategoryID, cancellationToken);

                if (values == null)
                    throw new Exception("Category not found");

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

                var category = _mapper.Map(request, values);

                await _categoryRepository.UpdateAsync(category);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new BaseResponse
                {
                    Data = category,
                    Message = "Category updated successfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the category");
                throw new Exception("An error occurred while updating the category", ex);
            }
        }
    }
}
