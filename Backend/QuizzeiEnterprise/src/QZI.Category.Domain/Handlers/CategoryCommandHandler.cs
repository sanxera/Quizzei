using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Category.Domain.Exceptions;
using QZI.Category.Domain.Handlers.Commands;
using QZI.Category.Domain.Handlers.Response;
using QZI.Category.Domain.Repositories;
using QZI.Core.Exceptions;

namespace QZI.Category.Domain.Handlers
{
    public class CategoryCommandHandler :
        IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>,
        IRequestHandler<GetAllCategoriesCommand, GetAllCategoriesResponse>,
        IRequestHandler<GetCategoryByIdCommand, GetCategoryByIdResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var newCategory = Entities.Category.CreateQuizCategory(command.Request.Name);

                await _categoryRepository.AddAsync(newCategory);

                return new CreateCategoryResponse { Created = true };
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
