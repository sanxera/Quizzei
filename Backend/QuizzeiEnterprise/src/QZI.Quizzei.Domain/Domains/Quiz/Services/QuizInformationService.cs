using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Abstractions.UnitOfWork;
using QZI.Quizzei.Domain.Domains.Categories.Entities;
using QZI.Quizzei.Domain.Domains.Categories.Repositories;
using QZI.Quizzei.Domain.Domains.Questions.Repositories;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Abstractions;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Requests.Information;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Response.Information;
using QZI.Quizzei.Domain.Domains.User.Service.Abstractions;
using QZI.Quizzei.Domain.Domains.User.Service.Response;

namespace QZI.Quizzei.Domain.Domains.Quiz.Services
{
    public class QuizInformationService : IQuizInformationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuizInfoRepository _quizInfoRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuizProcessRepository _quizProcessRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IQuizRateRepository _quizRateRepository;
        private readonly IUserService _userService;

        public QuizInformationService(IQuizInfoRepository quizInfoRepository, IUserService userService, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IQuestionRepository questionRepository, IQuizProcessRepository quizProcessRepository, IAnswerRepository answerRepository, IQuizRateRepository quizRateRepository)
        {
            _quizInfoRepository = quizInfoRepository;
            _userService = userService;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _questionRepository = questionRepository;
            _quizProcessRepository = quizProcessRepository;
            _answerRepository = answerRepository;
            _quizRateRepository = quizRateRepository;
        }

        public async Task<CreateQuizInfoResponse> CreateQuizInformation(string emailOwner, CreateQuizInfoRequest request)
        {
            var category = await _categoryRepository.GetCategoryById(request.CategoryId);
            var userResponse = await _userService.GetUserByEmail(emailOwner);

            var quizInfo = QuizInformation.CreateQuizInfo(request.Title, request.Description, userResponse.Id, category.Id);
            await _quizInfoRepository.AddAsync(quizInfo);

            await _unitOfWork.SaveChangesAsync();

            return new CreateQuizInfoResponse { CreatedQuizUuid = quizInfo.QuizInfoUuid };
        }

        public async Task<GetQuizzesResponse> GetQuizzesInformationByUser(Guid userUuid)
        {
            var user = await _userService.GetUserById(userUuid);
            var quizzes = await _quizInfoRepository.GetQuizInfoByUserUuid(user.Id);

            var response = await CreateQuizzesResponse(quizzes, user);

            return response;
        }

        public async Task<GetQuizzesResponse> GetQuizzesInformationByUser(string emailOwner)
        {
            var user = await _userService.GetUserByEmail(emailOwner);
            var quizzes = await _quizInfoRepository.GetQuizInfoByUserUuid(user.Id);

            var response = await CreateQuizzesResponse(quizzes, user);

            return response;
        }

        public async Task<GetQuizzesResponse> GetQuizzesInformationByDifferentUser(string emailOwner)
        {
            var user = await _userService.GetUserByEmail(emailOwner);
            var quizzes = await _quizInfoRepository.GetQuizInfoByDifferentUsers(user.Id);

            var response = await CreateQuizzesResponse(quizzes, user);

            return response;
        }

        public async Task<GetQuizzesByCategoryResponse> GetQuizzesInfoSeparateByCategoriesFromDifferentUsers(string emailOwner)
        {
            var response = new GetQuizzesByCategoryResponse();
            var categories = await _categoryRepository.GetCategoriesInRange(5);

            foreach (var category in categories)
            {
                var quizzesByCategory = await _quizInfoRepository.GetQuizzesByCategory(category.Id);
                var quizzesByCategoryResponse = new QuizzesByCategory { CategoryName = category.Description };

                await CreateQuizzesResponsePerCategory(quizzesByCategory, category, quizzesByCategoryResponse);

                response.QuizzesByCategories.Add(quizzesByCategoryResponse);
            }

            return response;
        }

        public async Task<GetQuizzesHistoryFromUserResponse> GetQuizzesHistoryFromUser(string emailOwner)
        {
            var user = await _userService.GetUserByEmail(emailOwner);

            var quizzesProcess = await _quizProcessRepository.GetQuizProcessByUser(user.Id);
            await GetQuizInformationByProcess(quizzesProcess);

            return await CreateQuizzesHistoryResponse(quizzesProcess, user);
        }

        private async Task<GetQuizzesResponse> CreateQuizzesResponse(IEnumerable<QuizInformation> quizzes, UserBaseResponse user)
        {
            var response = new GetQuizzesResponse();

            foreach (var quiz in quizzes)
            {
                var category = await _categoryRepository.GetCategoryById(quiz.CategoryId);
                var questions = await _questionRepository.GetQuestionsByQuizInfo(quiz.QuizInfoUuid);

                response.QuizzesInfoDto.Add(new QuizInfoResponse
                {
                    Title = quiz.Title,
                    Description = quiz.Description,
                    CategoryDescription = category.Description,
                    QuizInfoUuid = quiz.QuizInfoUuid,
                    NumberOfQuestions = questions.Count,
                    OwnerNickName = user.NickName
                });
            }

            return response;
        }

        private async Task<GetQuizzesHistoryFromUserResponse> CreateQuizzesHistoryResponse(IEnumerable<QuizProcess> quizProcesses, UserBaseResponse user)
        {
            var response = new GetQuizzesHistoryFromUserResponse
            {
                UserUuid = user.Id
            };

            foreach (var quizProcess in quizProcesses)
            {
                var category = await _categoryRepository.GetCategoryById(quizProcess.QuizInformation.CategoryId);
                var questions = await _questionRepository.GetQuestionsByQuizInfo(quizProcess.QuizInformation.QuizInfoUuid);
                var correctAnswers = _answerRepository.GetCorrectAnswersCountByQuizProcess(quizProcess.QuizProcessUuid);
                var quizRate = await _quizRateRepository.GetRateFromQuizProcess(quizProcess.QuizProcessUuid);

                response.QuizzesHistoryInformation.Add(new QuizHistoryInformation
                {
                    Title = quizProcess.QuizInformation.Title,
                    Description = quizProcess.QuizInformation.Description,
                    CategoryDescription = category.Description,
                    QuizInfoUuid = quizProcess.QuizInformation.QuizInfoUuid,
                    NumberOfQuestions = questions.Count,
                    CorrectAnswers = correctAnswers,
                    Rate = quizRate,
                    OwnerNickName = user.NickName
                });
            }

            return response;
        }

        private async Task CreateQuizzesResponsePerCategory(IEnumerable<QuizInformation> quizzesByCategory, Category category, QuizzesByCategory quizzesByCategoryResponse)
        {
            foreach (var quiz in quizzesByCategory)
            {
                var questions = await _questionRepository.GetQuestionsByQuizInfo(quiz.QuizInfoUuid);
                var quizResponse = new QuizInfoResponse
                {
                    Title = quiz.Title,
                    Description = quiz.Description,
                    CategoryDescription = category.Description,
                    QuizInfoUuid = quiz.QuizInfoUuid,
                    NumberOfQuestions = questions.Count,
                    OwnerNickName = await GetUserOwnerNickName(quiz.UserOwnerId)
                };

                quizzesByCategoryResponse.QuizzesInfoResponses.Add(quizResponse);
            }
        }

        private async Task<string> GetUserOwnerNickName(Guid userUuid)
        {
            var user = await _userService.GetUserById(userUuid);

            return user == null ? "Admin" : user.NickName;
        }

        private async Task GetQuizInformationByProcess(IEnumerable<QuizProcess> quizzesProcess)
        {
            foreach (var quizProcess in quizzesProcess)
            {
                quizProcess.QuizInformation = await _quizInfoRepository.GetQuizInfoById(quizProcess.QuizInfoUuid);
            }
        }
    }
}
