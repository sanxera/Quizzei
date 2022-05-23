using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Core.Exceptions;
using QZI.Quiz.Domain.Quiz.Acl.Interface;
using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Handlers.Commands.Quiz;
using QZI.Quiz.Domain.Quiz.Handlers.Response.Quiz;
using QZI.Quiz.Domain.Quiz.Repositories;
using QZI.Quiz.Domain.Quiz.UnitOfWork;

namespace QZI.Quiz.Domain.Quiz.Handlers
{
    public class QuizInfoCommandHandler : IRequestHandler<CreateQuizInfoCommand, CreateQuizInfoResponse>
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
    }
}
