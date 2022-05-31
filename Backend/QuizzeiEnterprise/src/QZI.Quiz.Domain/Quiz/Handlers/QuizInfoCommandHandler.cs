using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Quiz.Domain.Quiz.Acl.Interface;
using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Handlers.Commands;
using QZI.Quiz.Domain.Quiz.Handlers.Response;
using QZI.Quiz.Domain.Quiz.Repositories;
using QZI.Quiz.Domain.Quiz.UnitOfWork;

namespace QZI.Quiz.Domain.Quiz.Handlers
{
    public class QuizInfoCommandHandler : 
        IRequestHandler<CreateQuizInfoCommand, CreateQuizInfoResponse>,
        IRequestHandler<GetQuizzesInfoByUserCommand, GetQuizzesInfoByUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuizInfoRepository _quizInfoRepository;
        private readonly ICategoryServiceAcl _categoryServiceAcl;
        private readonly IUserServiceAcl _userServiceAcl;

        public QuizInfoCommandHandler(IQuizInfoRepository quizInfoRepository, IUserServiceAcl userServiceAcl, ICategoryServiceAcl categoryServiceAcl, IUnitOfWork unitOfWork)
        {
            _quizInfoRepository = quizInfoRepository;
            _userServiceAcl = userServiceAcl;
            _categoryServiceAcl = categoryServiceAcl;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateQuizInfoResponse> Handle(CreateQuizInfoCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryServiceAcl.GetCategoryById(command.Request.CategoryId);
            var userResponse = await _userServiceAcl.GetUserIdByEmail(command.UserEmail);

            var quizInfo = QuizInfo.CreateQuizInfo(command.Request.Title, command.Request.Description, command.Request.Points, userResponse.Id, category.Id);
            await _quizInfoRepository.AddAsync(quizInfo);

            await _unitOfWork.SaveChangesAsync();

            return new CreateQuizInfoResponse { CreatedQuizUuid = quizInfo.QuizInfoUuid };
        }

        public async Task<GetQuizzesInfoByUserResponse> Handle(GetQuizzesInfoByUserCommand byUserCommand, CancellationToken cancellationToken)
        {
            var userResponse = await _userServiceAcl.GetUserIdByEmail(byUserCommand.Request.Email);
            var quizzes = await _quizInfoRepository.GetQuizInfoByUserUuid(userResponse.Id);

            var response = new GetQuizzesInfoByUserResponse();

            foreach (var quiz in quizzes)
            {
                var category = await _categoryServiceAcl.GetCategoryById(quiz.CategoryId);

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
