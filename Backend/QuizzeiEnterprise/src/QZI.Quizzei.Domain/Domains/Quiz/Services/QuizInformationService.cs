using System.Collections.Generic;
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
        private readonly IUserService _userService;

        public QuizInformationService(IQuizInfoRepository quizInfoRepository, IUserService userService, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IQuestionRepository questionRepository)
        {
            _quizInfoRepository = quizInfoRepository;
            _userService = userService;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _questionRepository = questionRepository;
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

        public async Task<GetQuizzesResponse> GetQuizzesInformationByUser(string emailOwner)
        {
            var user = await _userService.GetUserByEmail(emailOwner);
            var quizzes = await _quizInfoRepository.GetQuizInfoByUserUuid(user.Id);

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

        public async Task<GetQuizzesResponse> GetQuizzesInformationByDifferentUser(string emailOwner)
        {
            var user = await _userService.GetUserByEmail(emailOwner);
            var quizzes = await _quizInfoRepository.GetQuizInfoByDifferentUsers(user.Id);

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

        public async Task<GetQuizzesByCategoryResponse> GetQuizzesInfoSeparateByCategoriesFromDifferentUsers(string emailOwner)
        {
            var response = new GetQuizzesByCategoryResponse();
            var user = await _userService.GetUserByEmail(emailOwner);
            var categories = await _categoryRepository.GetCategoriesInRange(5);

            foreach (var category in categories)
            {
                var quizzesByCategory = await _quizInfoRepository.GetQuizzesByCategory(category.Id);
                var quizzesByCategoryResponse = new QuizzesByCategory { CategoryName = category.Description };

                await CreateQuizzesResponse(quizzesByCategory, category, user, quizzesByCategoryResponse);

                response.QuizzesByCategories.Add(quizzesByCategoryResponse);
            }

            return response;
        }

        private async Task CreateQuizzesResponse(IEnumerable<QuizInformation> quizzesByCategory, Category category, UserBaseResponse user,
            QuizzesByCategory quizzesByCategoryResponse)
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
                    OwnerNickName = user.NickName
                };

                quizzesByCategoryResponse.QuizzesInfoResponses.Add(quizResponse);
            }
        }
    }
}
