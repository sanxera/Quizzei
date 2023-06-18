using QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerCategory.Interfaces;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerCategory.Models.Request;
using QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerCategory.Models.Response;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Enums;

namespace QZI.Quizzei.Application.UseCases.Analytics.QuizReportPerCategory
{
    public class QuizReportPerCategoryUseCase : IQuizReportPerCategoryUseCase
    {
        private readonly IQuizInfoRepository _quizInfoRepository;
        private readonly IQuizProcessRepository _quizProcessRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionOptionRepository _questionOptionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly ICategoryRepository _categoryRepository;

        public QuizReportPerCategoryUseCase(IQuizInfoRepository quizInfoRepository, IQuizProcessRepository quizProcessRepository, IQuestionRepository questionRepository, IQuestionOptionRepository questionOptionRepository, IAnswerRepository answerRepository, ICategoryRepository categoryRepository)
        {
            _quizInfoRepository = quizInfoRepository;
            _quizProcessRepository = quizProcessRepository;
            _questionRepository = questionRepository;
            _questionOptionRepository = questionOptionRepository;
            _answerRepository = answerRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<QuizReportPerCategoryResponse> ExecuteAsync(QuizReportPerCategoryRequest request)
        {
            var quizInfo = await _quizInfoRepository.GetQuizInfoById(request.QuizUuid);
            var quizProcesses = await _quizProcessRepository.GetQuizProcessByQuiz(request.QuizUuid);
            var questions = await _questionRepository.GetQuestionsByQuizInfo(quizInfo.QuizInfoUuid);

            var categoriesId = questions.Select(x => x.CategoryId).Distinct();

            var questionCategoriesResponse = new List<QuestionCategoryAnalyticsResponse>();
            foreach (var categoryId in categoriesId)
            {
                var category = await _categoryRepository.GetCategoryById(categoryId);
                var questionsByCategory = questions.Where(x => x.CategoryId == categoryId).ToList();

                var questionsResponse = new List<QuestionAnalyticsResponse>();
                foreach (var question in questionsByCategory)
                {
                    var validAnswers = await GetValidAnswers(question, quizProcesses);
                    var options = await _questionOptionRepository.GetQuestionOptionsByQuestionUuid(question.QuestionUuid);
                    var optionsResponse = CreateOptionAnalyticsResponses(options, validAnswers);
                    var totalAnswers = optionsResponse.Select(x => x.TotalOptionAnswers).Sum();
                    var totalHitPercentage = totalAnswers != 0 ? (optionsResponse.Select(x => x.HitQuantity).Sum() * 100) / totalAnswers : 0;
                    questionsResponse.Add(QuestionAnalyticsResponse.Create(question.QuestionUuid, question.Description, totalAnswers, totalHitPercentage, optionsResponse));
                }


                var questionCategoryResponse = QuestionCategoryAnalyticsResponse.Create(categoryId, questionsByCategory.Count, questionsResponse.Sum(x => x.TotalHitPercentage) / questionsByCategory.Count, category.Description, questionsResponse);
                questionCategoriesResponse.Add(questionCategoryResponse);
            }

            var totalCompletedQuiz = quizProcesses.Count(x => x.Status == QuizProcessStatus.Finished);
            var totalUncompletedQuiz = quizProcesses.Count(x => x.Status is QuizProcessStatus.Started or QuizProcessStatus.Cancelled);
            var totalQuestions = questions.Count;

            foreach (var questionCategoryAnalyticsResponse in questionCategoriesResponse)
            {
                foreach (var question in questionCategoryAnalyticsResponse.Questions)
                {
                    foreach (var option in question.Options)
                    {
                        option.TotalOptionAnswersPercentage = option.TotalOptionAnswers != 0
                            ? (option.TotalOptionAnswers * 100) / question.TotalAnswers
                            : 0;
                    }
                }
            }

            return QuizReportPerCategoryResponse.Create(request.QuizUuid, totalCompletedQuiz, totalUncompletedQuiz, totalQuestions, questionCategoriesResponse, quizInfo.Description);
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

                optionsResponse.Add(OptionAnalyticsResponse.Create(option.QuestionOptionUuid, option.Description, option.IsCorrect, 
                    totalAnswer, totalHitQuantity, totalHitPercentage));
            }

            return optionsResponse;
        }

        private async Task<List<Answer>> GetValidAnswers(Question question, IList<QuizProcess> quizProcesses)
        {
            var answers = await _answerRepository.GetAnswersByQuestion(question.QuestionUuid);
            var completedQuizzesUuids = quizProcesses.Where(x => x.Status == QuizProcessStatus.Finished)
                .Select(x => x.QuizProcessUuid.ToString());
            var validAnswers = answers.Where(x => completedQuizzesUuids.Contains(x.QuizProcessUuid.ToString())).ToList();
            return validAnswers;
        }
    }
}
