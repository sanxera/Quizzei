using System;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Abstractions.UnitOfWork;
using QZI.Quizzei.Domain.Domains.Questions.Repositories;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Abstractions;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Response.Process;
using QZI.Quizzei.Domain.Domains.User.Service.Abstractions;
using QZI.Quizzei.Domain.Exceptions;

namespace QZI.Quizzei.Domain.Domains.Quiz.Services
{
    public class QuizProcessService : IQuizProcessService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuizProcessRepository _quizProcessRepository;
        private readonly IQuizInfoRepository _quizInfoRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserService _userService;

        public QuizProcessService(IUnitOfWork unitOfWork, IQuizProcessRepository quizProcessRepository, IUserService userService, IQuizInfoRepository quizInfoRepository, IQuestionRepository questionRepository)
        {
            _unitOfWork = unitOfWork;
            _quizProcessRepository = quizProcessRepository;
            _userService = userService;
            _quizInfoRepository = quizInfoRepository;
            _questionRepository = questionRepository;
        }

        public async Task<StartQuizProcessResponse> StartQuizProcess(string emailOwner, Guid quizInfoUuid)
        {
            var userResponse = await _userService.GetUserByEmail(emailOwner);
            var quizInfo = await _quizInfoRepository.GetQuizInfoById(quizInfoUuid);

            await ValidateQuizQuestions(quizInfo.QuizInfoUuid);

            var quizProcess = QuizProcess.CreateQuizProcess(quizInfo.QuizInfoUuid, userResponse.Id);
            await _quizProcessRepository.AddAsync(quizProcess);

            await _unitOfWork.SaveChangesAsync();

            return new StartQuizProcessResponse { QuizProcessCreatedUuid = quizProcess.QuizProcessUuid };
        }

        private async Task ValidateQuizQuestions(Guid quizInfoUuid)
        {
            var questions = await _questionRepository.GetQuestionsByQuizInfo(quizInfoUuid);

            if (questions.Count == 0) throw new GenericException("This quiz has no questions !");
        }
    }
}
