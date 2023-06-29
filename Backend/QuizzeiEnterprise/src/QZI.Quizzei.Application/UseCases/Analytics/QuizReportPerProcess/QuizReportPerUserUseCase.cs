using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerProcess.Interfaces;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerProcess.Models.Requests;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerProcess.Models.Responses;

namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerProcess;

public class QuizReportPerProcessUseCase : IQuizReportPerProcessUseCase
{
    private readonly IQuizInfoRepository _quizInfoRepository;
    private readonly IQuizProcessRepository _quizProcessRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuestionOptionRepository _questionOptionRepository;
    private readonly IAnswerRepository _answerRepository;

    public QuizReportPerProcessUseCase(IQuizInfoRepository quizInfoRepository, IQuizProcessRepository quizProcessRepository, IQuestionRepository questionRepository, IQuestionOptionRepository questionOptionRepository, IAnswerRepository answerRepository)
    {
        _quizInfoRepository = quizInfoRepository;
        _quizProcessRepository = quizProcessRepository;
        _questionRepository = questionRepository;
        _questionOptionRepository = questionOptionRepository;
        _answerRepository = answerRepository;
    }

    public async Task<QuizReportPerProcessResponse> ExecuteAsync(QuizReportPerProcessRequest request)
    {
        var quizProcess = await _quizProcessRepository.GetQuizProcessById(request.QuizProcessUuid);
        var quizInfo = await _quizInfoRepository.GetQuizInfoById(quizProcess.QuizInfoUuid);
        var questions = await _questionRepository.GetQuestionsByQuizInfo(quizInfo.QuizInfoUuid);

        var questionsListResponse = new List<QuestionAnalyticsResponse>();
        foreach (var question in questions)
        {
            var options = await _questionOptionRepository.GetQuestionOptionsByQuestionUuid(question.QuestionUuid);
            var answers = await _answerRepository.GetAnswersByQuestionAndProcess(question.QuestionUuid, quizProcess.QuizProcessUuid);

            var optionsListResponse = new List<OptionAnalyticsResponse>();
            var userCorrect = false;
            foreach (var option in options)
            {
                var answer = answers.FirstOrDefault(x => x.QuestionOptionUuid == option.QuestionOptionUuid);

                if (answer != null)
                {
                    userCorrect = answer.CorrectAnswer;
                    optionsListResponse.Add(OptionAnalyticsResponse.Create(option.QuestionOptionUuid, option.Description, option.IsCorrect, true));
                }
                else
                    optionsListResponse.Add(OptionAnalyticsResponse.Create(option.QuestionOptionUuid, option.Description, option.IsCorrect, false));
            }

            var timer = answers.FirstOrDefault(x => x.QuestionUuid == question.QuestionUuid)?.Timer ?? 0;
            questionsListResponse.Add(QuestionAnalyticsResponse.Create(question.QuestionUuid, question.Description, userCorrect, timer, optionsListResponse));
        }
        
        return new QuizReportPerProcessResponse(quizInfo.QuizInfoUuid, quizInfo.Description, questions.Count, questionsListResponse);
    }
}