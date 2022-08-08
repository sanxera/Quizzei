using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Quizzei.Domain.Abstractions.UnitOfWork;
using QZI.Quizzei.Domain.Domains.Category.Repositories;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Commands;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Response;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories;
using QZI.Quizzei.Domain.Domains.User.Service.Abstractions;

namespace QZI.Quizzei.Domain.Domains.Quiz.Handlers
{
    public class QuizInfoCommandHandler : 
        IRequestHandler<CreateQuizInfoCommand, CreateQuizInfoResponse>,
        IRequestHandler<GetQuizzesInfoByUserCommand, GetQuizzesInfoByUserResponse>,
        IRequestHandler<GetQuizzesInfoByDifferentUsersCommand, GetQuizzesInfoByDifferentUsersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuizInfoRepository _quizInfoRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserService _userService;

        public QuizInfoCommandHandler(IQuizInfoRepository quizInfoRepository, IUserService userService, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _quizInfoRepository = quizInfoRepository;
            _userService = userService;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateQuizInfoResponse> Handle(CreateQuizInfoCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryById(command.Request.CategoryId);
            var userResponse = await _userService.GetUserByEmail(command.UserEmail);

            var quizInfo = QuizInfo.CreateQuizInfo(command.Request.Title, command.Request.Description, command.Request.Points, userResponse.UserUuid, category.Id);
            await _quizInfoRepository.AddAsync(quizInfo);

            await _unitOfWork.SaveChangesAsync();

            return new CreateQuizInfoResponse { CreatedQuizUuid = quizInfo.QuizInfoUuid };
        }

        public async Task<GetQuizzesInfoByUserResponse> Handle(GetQuizzesInfoByUserCommand command, CancellationToken cancellationToken)
        {
            var userResponse = await _userService.GetUserByEmail(command.Request.UserEmail);
            var quizzes = await _quizInfoRepository.GetQuizInfoByUserUuid(userResponse.UserUuid);

            var response = new GetQuizzesInfoByUserResponse();

            foreach (var quiz in quizzes)
            {
                var category = await _categoryRepository.GetCategoryById(quiz.CategoryId);

                response.QuizzesInfoDto.Add(new QuizInfoResponse
                {
                    Title = quiz.Title,
                    Description = quiz.Description,
                    CategoryDescription = category.Description,
                    QuizInfoUuid = quiz.QuizInfoUuid
                });
            }

            return response;
        }

        public async Task<GetQuizzesInfoByDifferentUsersResponse> Handle(GetQuizzesInfoByDifferentUsersCommand request, CancellationToken cancellationToken)
        {
            var userResponse = await _userService.GetUserByEmail(request.ByDifferentUsersRequest.UserEmail);
            var quizzes = await _quizInfoRepository.GetQuizInfoByDifferentUsers(userResponse.UserUuid);

            var response = new GetQuizzesInfoByDifferentUsersResponse();

            foreach (var quiz in quizzes)
            {
                var category = await _categoryRepository.GetCategoryById(quiz.CategoryId);

                response.QuizzesInfoDto.Add(new QuizInfoResponse
                {
                    Title = quiz.Title,
                    Description = quiz.Description,
                    CategoryDescription = category.Description,
                    QuizInfoUuid = quiz.QuizInfoUuid
                });
            }

            return response;
        }
    }
}
