using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Core.Exceptions;
using QZI.Quiz.Domain.Quiz.Acl.Interface;
using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Handlers.Commands.Quiz;
using QZI.Quiz.Domain.Quiz.Handlers.Response.Quiz;
using QZI.Quiz.Domain.Quiz.Repositories;

namespace QZI.Quiz.Domain.Quiz.Handlers
{
    public class QuizInfoCommandHandler : IRequestHandler<CreateQuizInfoCommand, CreateQuizInfoResponse>
    {
        private readonly IQuizInfoRepository _quizInfoRepository;
        private readonly ICategoryServiceAcl _categoryServiceAcl;
        private readonly IUserServiceAcl _userServiceAcl;

        public QuizInfoCommandHandler(IQuizInfoRepository quizInfoRepository, IUserServiceAcl userServiceAcl, ICategoryServiceAcl categoryServiceAcl)
        {
            _quizInfoRepository = quizInfoRepository;
            _userServiceAcl = userServiceAcl;
            _categoryServiceAcl = categoryServiceAcl;
        }

        public async Task<CreateQuizInfoResponse> Handle(CreateQuizInfoCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryServiceAcl.GetCategoryById(command.Request.CategoryId);

            if (category == null)
                throw new NotFoundException("Category not found.");

            var userResponse = await _userServiceAcl.GetUserIdByEmail(command.UserEmail);

            var quizInfo = QuizInfo.CreateQuizInfo(command.Request.Title, command.Request.Description, command.Request.Points, userResponse.Id, category.Id);
            await _quizInfoRepository.AddAsync(quizInfo);

            return new CreateQuizInfoResponse { CreatedQuizUuid = quizInfo.QuizInfoUuid };
        }
    }
}
