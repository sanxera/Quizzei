using QZI.Quizzei.Application.UseCases.Questions.UpdateQuestionsUseCase.Models.Request;

namespace QZI.Quizzei.Application.Shared.Entities;

public class QuestionOption : Entity
{
    public Guid QuestionOptionUuid { get; set; }
    public string Description { get; set; } = null!;
    public bool IsCorrect { get; set; }
    public Guid QuestionUuid { get; set; }
    public Question Question { get; set; } = null!;

    public QuestionOption()
    {

    }

    //TODO: REFATORAR
    public QuestionOption(string description, bool isCorrect, Guid questionUuid, Question question)
    {
        Description = description;
        IsCorrect = isCorrect;
        QuestionUuid = questionUuid;
        Question = question;
    }

    public static List<QuestionOption> CreateAnyOptions(List<UpdateOptions> questionsRequest)
    {
        return questionsRequest.Select(CreateQuestionOption).ToList();
    }

    private static QuestionOption CreateQuestionOption(UpdateOptions request)
    {
        return new QuestionOption()
        {
            Description = request.Description,
            IsCorrect = request.IsCorrect,
            CreatedAt = DateTime.Now,
            CreatedBy = "Admin"
        };
    }
}