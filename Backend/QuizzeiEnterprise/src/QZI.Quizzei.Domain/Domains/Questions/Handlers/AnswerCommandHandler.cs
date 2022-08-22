using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Quizzei.Domain.Abstractions.UnitOfWork;
using QZI.Quizzei.Domain.Domains.Questions.Entities;
using QZI.Quizzei.Domain.Domains.Questions.Handlers.Commands;
using QZI.Quizzei.Domain.Domains.Questions.Handlers.Responses;
using QZI.Quizzei.Domain.Domains.Questions.Repositories;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories;
using QZI.Quizzei.Domain.Domains.User.Response;
using QZI.Quizzei.Domain.Domains.User.Service.Abstractions;
using QZI.Quizzei.Domain.Exceptions;

namespace QZI.Quizzei.Domain.Domains.Questions.Handlers
{
    public class AnswerCommandHandler : IRequestHandler<AnswerQuestionCommand, AnswerQuestionResponse>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IQuizProcessRepository _quizProcessRepository;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public AnswerCommandHandler(IQuestionRepository questionRepository, IAnswerRepository answerRepository, IUserService userService, IUnitOfWork unitOfWork, IQuizProcessRepository quizProcessRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _userService = userService;
            _unitOfWork = unitOfWork;
            _quizProcessRepository = quizProcessRepository;
        }

        public async Task<AnswerQuestionResponse> Handle(AnswerQuestionCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByEmail(request.Email);
            var question = await _questionRepository.GetQuestionById(request.Request.QuestionUuid);
            var quizProcess = await _quizProcessRepository.GetQuizInfoById(request.Request.QuizProcessUuid);

            ValidateAnswer(user, question, quizProcess);

            var selectedOption = question.Options.FirstOrDefault(x => x.QuestionOptionUuid == request.Request.OptionUuid);

            var newAnswer = Answer.CreateAnswer(selectedOption!.QuestionOptionUuid, quizProcess.QuizProcessUuid, user.Id, selectedOption.IsCorrect);

            await _answerRepository.AddAsync(newAnswer);

            await _unitOfWork.SaveChangesAsync();

            return new AnswerQuestionResponse{CorrectAnswer = newAnswer.CorrectAnswer};
        }

        private static void ValidateAnswer(UserBaseResponse user, Question question, QuizProcess quizProcess)
        {
            if (user is null || question is null || quizProcess is null)
            {
                throw new GenericException("Answer is invalid in this quiz process !");
            }
        }
    }
}
