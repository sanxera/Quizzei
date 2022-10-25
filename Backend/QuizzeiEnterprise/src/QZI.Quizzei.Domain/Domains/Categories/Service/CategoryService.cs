using System;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Abstractions.UnitOfWork;
using QZI.Quizzei.Domain.Domains.Categories.Repositories;
using QZI.Quizzei.Domain.Domains.Categories.Service.Abstractions;
using QZI.Quizzei.Domain.Domains.Categories.Service.Requests;
using QZI.Quizzei.Domain.Domains.Categories.Service.Response;
using QZI.Quizzei.Domain.Exceptions;

namespace QZI.Quizzei.Domain.Domains.Categories.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCategoryResponse> CreateCategory(CreateCategoryRequest request)
        {
            try
            {
                var newCategory = Entities.Category.CreateQuizCategory(request.Name);

                await _categoryRepository.AddAsync(newCategory);
                await _unitOfWork.SaveChangesAsync();

                return new CreateCategoryResponse { CreatedId = newCategory.Id };
            }
            catch (Exception ex)
            {
                throw new CategoryException("Error to create category.", ex);
            }
        }

        public async Task<GetAllCategoriesResponse> GetAllCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetAllCategories();
                return new GetAllCategoriesResponse(categories);
            }
            catch (Exception ex)
            {
                throw new CategoryException("Error to get all categories.", ex);
            }
        }

        public async Task<GetCategoryByIdResponse> GetCategoryById(int categoryId)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryById(categoryId);

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
