using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Quizzei.Domain.Abstractions.UnitOfWork;
using QZI.Quizzei.Domain.Domains.Questions.Repositories;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Commands.Process;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Response.Process;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories;
using QZI.Quizzei.Domain.Domains.User.Service.Abstractions;
using QZI.Quizzei.Domain.Exceptions;

namespace QZI.Quizzei.Domain.Domains.Quiz.Handlers
{
    public class QuizProcessCommandHandler : IRequestHandler<StartQuizProcessCommand, StartQuizProcessResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuizProcessRepository _quizProcessRepository;
        private readonly IQuizInfoRepository _quizInfoRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserService _userService;

        public QuizProcessCommandHandler(IUnitOfWork unitOfWork, IQuizProcessRepository quizProcessRepository, IUserService userService, IQuizInfoRepository quizInfoRepository, IQuestionRepository questionRepository)
        {
            _unitOfWork = unitOfWork;
            _quizProcessRepository = quizProcessRepository;
            _userService = userService;
            _quizInfoRepository = quizInfoRepository;
            _questionRepository = questionRepository;
        }

        public async Task<StartQuizProcessResponse> Handle(StartQuizProcessCommand request, CancellationToken cancellationToken)
        {
            var userResponse = await _userService.GetUserByEmail(request.UserEmail);
            var quizInfo = await _quizInfoRepository.GetQuizInfoById(request.Request.QuizUuid);

            await ValidateQuizQuestions(quizInfo.QuizInfoUuid);

            var quizProcess = QuizProcess.CreateQuizProcess(quizInfo.QuizInfoUuid, userResponse.Id);
            await _quizProcessRepository.AddAsync(quizProcess);

            await _unitOfWork.SaveChangesAsync();

            return new StartQuizProcessResponse {QuizProcessCreatedUuid = quizProcess.QuizProcessUuid};
        }

        private async Task ValidateQuizQuestions(Guid quizInfoUuid)
        {
            var questions = await _questionRepository.GetQuestionsByQuizInfo(quizInfoUuid);

            if (questions.Count == 0) throw new GenericException("This quiz has no questions !");
        }
    }
}
