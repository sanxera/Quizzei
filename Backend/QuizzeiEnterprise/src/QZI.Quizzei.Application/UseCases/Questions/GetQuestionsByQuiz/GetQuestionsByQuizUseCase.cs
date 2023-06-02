using QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz.Interfaces;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Enums;
using QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz.Models.Request;
using QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz.Models.Response;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.Services.Amazon.Interfaces;

namespace QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz;

public class GetQuestionsByQuizUseCase : IGetQuestionsByQuizUseCase
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IAmazonService _amazonService;

    public GetQuestionsByQuizUseCase(IQuestionRepository questionRepository, IAmazonService amazonService)
    {
        _questionRepository = questionRepository;
        _amazonService = amazonService;
    }

    public async Task<GetQuestionsWithOptionsByQuizResponse> ExecuteAsync(GetQuestionsByQuizRequest request)
    {
        var questions = await _questionRepository.GetQuestionsByQuizInfo(request.QuizInfoUuid);

        var response = await CreateQuestionResponse(questions);

        return response;
    }

    private async Task<GetQuestionsWithOptionsByQuizResponse> CreateQuestionResponse(IEnumerable<Question> questions)
    {
        var questionToReturn = new GetQuestionsWithOptionsByQuizResponse();

        foreach (var question in questions)
        {
            var imagesUrl = await GetImagesUrl(question);
            var questionDto = QuestionResponse.Create(question.QuestionUuid, question.Description, question.CategoryId, imagesUrl, CreateOptionsResponse(question));
            questionToReturn.Questions.Add(questionDto);
        }

        return questionToReturn;
    }

    public async Task<List<QuestionImageResponse>> GetImagesUrl(Question question)
    {
        var imagesUrl = new List<QuestionImageResponse>();
        foreach (var questionImage in question.Images)
        {
            var amazonUrl = await _amazonService.GetObjectUrl(questionImage.ImageName, FileType.Image);

            imagesUrl.Add(QuestionImageResponse.Create(questionImage.QuestionImageUuid, questionImage.ImageName, amazonUrl));
        }

        return imagesUrl;
    }

    private static IList<QuestionOptionResponse> CreateOptionsResponse(Question question)
    {
        return question.Options
            .Select(option => QuestionOptionResponse.Create(option.QuestionOptionUuid, option.Description, option.IsCorrect))
            .ToList();
    }
}