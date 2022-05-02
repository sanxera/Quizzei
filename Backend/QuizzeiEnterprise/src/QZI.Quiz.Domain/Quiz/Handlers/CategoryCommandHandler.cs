using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Exceptions;
using QZI.Quiz.Domain.Quiz.Handlers.Commands;
using QZI.Quiz.Domain.Quiz.Handlers.Response;
using QZI.Quiz.Domain.Quiz.Repositories;

namespace QZI.Quiz.Domain.Quiz.Handlers
{
    public class CategoryCommandHandler :
        IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>,
        IRequestHandler<GetAllCategoriesCommand, GetAllCategoriesResponse>
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
                var newCategory = QuizCategory.CreateQuizCategory(command.Request.Name);

                await _categoryRepository.AddNewCategory(newCategory);

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
                var categories = _categoryRepository.GetAllCategories();
                var dto = new GetAllCategoriesResponse();

                dto.CreateListOfCategoryDto(categories);
                return dto;
            }
            catch (Exception ex)
            {
                throw new CategoryException("Error to get all categories.", ex);
            }
        }
    }
}
