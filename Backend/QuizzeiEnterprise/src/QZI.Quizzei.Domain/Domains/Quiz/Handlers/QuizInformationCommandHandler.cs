using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Quizzei.Domain.Abstractions.UnitOfWork;
using QZI.Quizzei.Domain.Domains.Category.Repositories;
using QZI.Quizzei.Domain.Domains.Questions.Repositories;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Commands.Information;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Response.Information;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories;
using QZI.Quizzei.Domain.Domains.User.Service.Abstractions;

namespace QZI.Quizzei.Domain.Domains.Quiz.Handlers
{
    public class QuizInformationCommandHandler : 
        IRequestHandler<CreateQuizInfoCommand, CreateQuizInfoResponse>,
        IRequestHandler<GetQuizzesInfoByUserCommand, GetQuizzesInfoByUserResponse>,
        IRequestHandler<GetQuizzesInfoByDifferentUsersCommand, GetQuizzesInfoByDifferentUsersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuizInfoRepository _quizInfoRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserService _userService;

        public QuizInformationCommandHandler(IQuizInfoRepository quizInfoRepository, IUserService userService, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IQuestionRepository questionRepository)
        {
            _quizInfoRepository = quizInfoRepository;
            _userService = userService;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _questionRepository = questionRepository;
        }

        public async Task<CreateQuizInfoResponse> Handle(CreateQuizInfoCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryById(command.Request.CategoryId);
            var userResponse = await _userService.GetUserByEmail(command.UserEmail);

            var quizInfo = QuizInformation.CreateQuizInfo(command.Request.Title, command.Request.Description, command.Request.Points, userResponse.Id, category.Id);
            await _quizInfoRepository.AddAsync(quizInfo);

            await _unitOfWork.SaveChangesAsync();

            return new CreateQuizInfoResponse { CreatedQuizUuid = quizInfo.QuizInfoUuid };
        }

        public async Task<GetQuizzesInfoByUserResponse> Handle(GetQuizzesInfoByUserCommand command, CancellationToken cancellationToken)
        {
            var userResponse = await _userService.GetUserByEmail(command.Request.UserEmail);
            var quizzes = await _quizInfoRepository.GetQuizInfoByUserUuid(userResponse.Id);

            var response = new GetQuizzesInfoByUserResponse();

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
                    NumberOfQuestions = questions.Count
                });
            }

            return response;
        }

        public async Task<GetQuizzesInfoByDifferentUsersResponse> Handle(GetQuizzesInfoByDifferentUsersCommand request, CancellationToken cancellationToken)
        {
            var userResponse = await _userService.GetUserByEmail(request.ByDifferentUsersRequest.UserEmail);
            var quizzes = await _quizInfoRepository.GetQuizInfoByDifferentUsers(userResponse.Id);

            var response = new GetQuizzesInfoByDifferentUsersResponse();

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
                    NumberOfQuestions = questions.Count
                });
            }

            return response;
        }
    }
}
