using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Quiz.Domain.Quiz.Acl.Interface;
using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Exceptions;
using QZI.Quiz.Domain.Quiz.Handlers.Commands.Quiz;
using QZI.Quiz.Domain.Quiz.Handlers.Response.Quiz;
using QZI.Quiz.Domain.Quiz.Repositories;

namespace QZI.Quiz.Domain.Quiz.Handlers
{
    public class QuizInfoCommandHandler : IRequestHandler<CreateQuizInfoCommand, CreateQuizInfoResponse>
    {
        private readonly IQuizInfoRepository _quizInfoRepository;
        private readonly ICategoryRepository _quizCategoryRepository;
        private readonly IUserServiceAcl _userServiceAcl;

        public QuizInfoCommandHandler(IQuizInfoRepository quizInfoRepository, ICategoryRepository quizCategoryRepository, IUserServiceAcl userServiceAcl)
        {
            _quizInfoRepository = quizInfoRepository;
            _quizCategoryRepository = quizCategoryRepository;
            _userServiceAcl = userServiceAcl;
        }

        public async Task<CreateQuizInfoResponse> Handle(CreateQuizInfoCommand command, CancellationToken cancellationToken)
        {
            var category = await _quizCategoryRepository.GetCategoryById(command.Request.CategoryId);

            if (category == null)
                throw new CategoryException("Category not found.");

            var userResponse = await _userServiceAcl.GetUserIdByEmail(new GetUserByEmailRequest {Email = command.UserEmail});

            var quizInfo = QuizInfo.CreateQuizInfo(command.Request.Title, command.Request.Description, command.Request.Points, userResponse.Id, category);
            await _quizInfoRepository.AddAsync(quizInfo);

            return new CreateQuizInfoResponse { CreatedQuizUuid = quizInfo.QuizInfoUuid };
        }
    }
}
