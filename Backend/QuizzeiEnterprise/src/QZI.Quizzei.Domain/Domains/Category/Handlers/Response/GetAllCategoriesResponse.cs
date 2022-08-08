using System.Collections.Generic;
using QZI.Quizzei.Domain.Domains.Category.Dtos;

namespace QZI.Quizzei.Domain.Domains.Category.Handlers.Response
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
