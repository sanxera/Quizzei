using System.Collections.Generic;
using QZI.Category.Domain.Dtos;

namespace QZI.Category.Domain.Handlers.Response
{
    public class GetAllCategoriesResponse
    {
        public IList<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public GetAllCategoriesResponse(IEnumerable<Entities.Category> quizCategories)
        {
            foreach (var quizCategory in quizCategories)
            {
                Categories.Add(new CategoryDto(quizCategory.Id, quizCategory.Description));
            }
        }
    }
}
