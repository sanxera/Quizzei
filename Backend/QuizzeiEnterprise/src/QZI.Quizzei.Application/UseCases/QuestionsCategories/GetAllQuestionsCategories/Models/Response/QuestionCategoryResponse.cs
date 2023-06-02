namespace QZI.Quizzei.Application.UseCases.QuestionsCategories.GetAllQuestionsCategories.Models.Response;

public class QuestionCategoryResponse
{
    public int IdCategory { get; set; }
    public string Name { get; set; }

    public QuestionCategoryResponse(int idCategory, string name)
    {
        IdCategory = idCategory;
        Name = name;
    }
}