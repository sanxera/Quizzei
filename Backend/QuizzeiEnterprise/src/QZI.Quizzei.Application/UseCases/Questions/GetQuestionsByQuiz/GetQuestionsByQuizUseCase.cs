using QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz.Interfaces;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz.Models.Request;
using QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz.Models.Response;
using QZI.Quizzei.Application.Shared.Repositories;

namespace QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz;

public class GetQuestionsByQuizUseCase : IGetQuestionsByQuizUseCase
{
    private readonly IQuestionRepository _questionRepository;

    public GetQuestionsByQuizUseCase(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<GetQuestionsWithOptionsByQuizResponse> ExecuteAsync(GetQuestionsByQuizRequest request)
    {
        var questions = await _questionRepository.GetQuestionsByQuizInfo(request.QuizInfoUuid);

        return CreateQuestionResponse(questions);
    }

    private static GetQuestionsWithOptionsByQuizResponse CreateQuestionResponse(IEnumerable<Question> questions)
    {
        var questionToReturn = new GetQuestionsWithOptionsByQuizResponse();

        foreach (var question in questions)
        {
            var questionDto = QuestionResponse.Create(question.QuestionUuid, question.Description, CreateOptionsResponse(question));
            questionToReturn.Questions.Add(questionDto);
        }

        return questionToReturn;
    }

    private static IList<QuestionOptionResponse> CreateOptionsResponse(Question question)
    {
        return question.Options
            .Select(option => QuestionOptionResponse.Create(option.QuestionOptionUuid, option.Description, option.IsCorrect))
            .ToList();
    }
}