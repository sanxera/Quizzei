using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Enums;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReport.Interfaces;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReport.Models.Request;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReport.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReport;

public class QuizReportUseCase : IQuizReportUseCase
{
    private readonly IQuizInfoRepository _quizInfoRepository;
    private readonly IQuizProcessRepository _quizProcessRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuestionOptionRepository _questionOptionRepository;
    private readonly IAnswerRepository _answerRepository;

    public QuizReportUseCase(IQuizInfoRepository quizInfoRepository, IQuizProcessRepository quizProcessRepository, IQuestionOptionRepository questionOptionRepository, IQuestionRepository questionRepository, IAnswerRepository answerRepository)
    {
        _quizInfoRepository = quizInfoRepository;
        _quizProcessRepository = quizProcessRepository;
        _questionOptionRepository = questionOptionRepository;
        _questionRepository = questionRepository;
        _answerRepository = answerRepository;
    }

    public async Task<QuizReportResponse> ExecuteAsync(QuizReportRequest request)
    {
        var quizInfo = await _quizInfoRepository.GetQuizInfoById(request.QuizUuid);
        var quizProcesses = await _quizProcessRepository.GetQuizProcessByUser(request.QuizUuid);
        var questions = await _questionRepository.GetQuestionsByQuizInfo(quizInfo.QuizInfoUuid);

        var questionsResponse = new List<QuestionAnalyticsResponse>();
        foreach (var question in questions)
        {
            var answers = await _answerRepository.GetAnswersByQuestion(question.QuestionUuid);
            var options = await _questionOptionRepository.GetQuestionOptionsByQuestionUuid(question.QuestionUuid);

            var optionsResponse = CreateOptionAnalyticsResponses(options, answers);
            questionsResponse.Add(QuestionAnalyticsResponse.Create(question.QuestionUuid, question.Description, optionsResponse));
        }

        var totalCompletedQuiz = quizProcesses.Count(x => x.Status == QuizProcessStatus.Finished);
        var totalUncompletedQuiz = quizProcesses.Count(x => x.Status is QuizProcessStatus.Started or QuizProcessStatus.Cancelled);
        var totalQuestions = questions.Count;

        return QuizReportResponse.Create(request.QuizUuid, quizInfo.Description, totalCompletedQuiz, totalUncompletedQuiz, totalQuestions, questionsResponse);
    }

    private static List<OptionAnalyticsResponse> CreateOptionAnalyticsResponses(IList<QuestionOption> options, IList<Answer> answers)
    {
        var optionsResponse = new List<OptionAnalyticsResponse>();

        foreach (var option in options)
        {
            var answerForOption = answers.Where(x => x.QuestionOptionUuid == option.QuestionOptionUuid).ToList();

            var totalAnswer = answerForOption.Count;
            var totalHitQuantity = answerForOption.Count(x => x.CorrectAnswer);
            var totalHitPercentage = totalAnswer != 0 ? (totalHitQuantity * 100) / totalAnswer : 0;

            optionsResponse.Add(OptionAnalyticsResponse.Create(option.QuestionOptionUuid, option.Description, totalAnswer,
                totalHitQuantity, totalHitPercentage));
        }

        return optionsResponse;
    }
}