using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Quiz.Domain.Quiz.Acl.Interface;
using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Handlers.Commands.Process;
using QZI.Quiz.Domain.Quiz.Handlers.Response.Process;
using QZI.Quiz.Domain.Quiz.Repositories;
using QZI.Quiz.Domain.Quiz.UnitOfWork;

namespace QZI.Quiz.Domain.Quiz.Handlers
{
    public class QuizProcessCommandHandler : IRequestHandler<StartQuizProcessCommand, StartQuizProcessResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuizProcessRepository _quizProcessRepository;
        private readonly IQuizInfoRepository _quizInfoRepository;
        private readonly IUserServiceAcl _userServiceAcl;

        public QuizProcessCommandHandler(IUnitOfWork unitOfWork, IQuizProcessRepository quizProcessRepository, IUserServiceAcl userServiceAcl, IQuizInfoRepository quizInfoRepository)
        {
            _unitOfWork = unitOfWork;
            _quizProcessRepository = quizProcessRepository;
            _userServiceAcl = userServiceAcl;
            _quizInfoRepository = quizInfoRepository;
        }

        public async Task<StartQuizProcessResponse> Handle(StartQuizProcessCommand request, CancellationToken cancellationToken)
        {
            var userResponse = await _userServiceAcl.GetUserIdByEmail(request.UserEmail);
            var quizInfo = await _quizInfoRepository.GetQuizInfoById(request.Request.QuizUuid);

            var quizProcess = QuizProcess.CreateQuizProcess(quizInfo.QuizInfoUuid, userResponse.Id);
            await _quizProcessRepository.AddAsync(quizProcess);

            await _unitOfWork.SaveChangesAsync();

            return new StartQuizProcessResponse {QuizProcessCreatedUuid = quizProcess.QuizProcessUuid};
        }
    }
}
