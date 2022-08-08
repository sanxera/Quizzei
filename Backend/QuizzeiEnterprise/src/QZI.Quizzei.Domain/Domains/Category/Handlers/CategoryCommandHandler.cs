using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Quizzei.Domain.Abstractions.UnitOfWork;
using QZI.Quizzei.Domain.Domains.Category.Handlers.Commands;
using QZI.Quizzei.Domain.Domains.Category.Handlers.Response;
using QZI.Quizzei.Domain.Domains.Category.Repositories;
using QZI.Quizzei.Domain.Exceptions;

namespace QZI.Quizzei.Domain.Domains.Category.Handlers
{
    public class CategoryCommandHandler :
        IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>,
        IRequestHandler<GetAllCategoriesCommand, GetAllCategoriesResponse>,
        IRequestHandler<GetCategoryByIdCommand, GetCategoryByIdResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var newCategory = Entities.Category.CreateQuizCategory(command.Request.Name);

                await _categoryRepository.AddAsync(newCategory);
                await _unitOfWork.SaveChangesAsync();

                return new CreateCategoryResponse { CreatedId = newCategory.Id };
            }
            catch (Exception ex)
            {
                throw new CategoryException("Error to create category.", ex);
            }
        }

        public async Task<GetAllCategoriesResponse> Handle(GetAllCategoriesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _categoryRepository.GetAllCategories();
;
                return new GetAllCategoriesResponse(categories);
            }
            catch (Exception ex)
            {
                throw new CategoryException("Error to get all categories.", ex);
            }
        }

        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryById(request.Request.Id);

                if (category == null)
                    throw new NotFoundException("Category not found !");
                
                return new GetCategoryByIdResponse { Id = category.Id, Description = category.Description };
            }
            catch (Exception ex)
            {
                throw new CategoryException("Error to get category.", ex);
            }
        }
    }
}
