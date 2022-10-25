using System.Collections.Generic;

namespace QZI.Quizzei.Domain.Domains.Categories.Service.Response
{
    public class GetAllCategoriesResponse
    {
        public IList<CategoryResponse> Categories { get; set; } = new List<CategoryResponse>();

        public GetAllCategoriesResponse(IEnumerable<Entities.Category> quizCategories)
        {
            foreach (var quizCategory in quizCategories)
            {
                Categories.Add(new CategoryResponse(quizCategory.Id, quizCategory.Description));
            }
        }
    }

    public class CategoryResponse
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }

        public CategoryResponse(int idCategory, string name)
        {
            IdCategory = idCategory;
            Name = name;
        }
    }
}
