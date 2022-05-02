using System.Collections.Generic;
using QZI.Quiz.Domain.Quiz.Dtos;
using QZI.Quiz.Domain.Quiz.Entities;

namespace QZI.Quiz.Domain.Quiz.Handlers.Response
{
    public class GetAllCategoriesResponse
    {
        public IList<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public void CreateListOfCategoryDto(IList<QuizCategory> quizCategories)
        {
            foreach (var quizCategory in quizCategories)
            {
                Categories.Add(new CategoryDto(quizCategory.QuizCategoryId, quizCategory.Description));
            }
        }
    }
}
