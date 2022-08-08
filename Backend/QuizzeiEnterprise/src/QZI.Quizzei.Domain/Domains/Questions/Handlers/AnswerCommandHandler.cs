using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Quizzei.Domain.Domains.Questions.Entities;
using QZI.Quizzei.Domain.Domains.Questions.Handlers.Commands;
using QZI.Quizzei.Domain.Domains.Questions.Handlers.Responses;
using QZI.Quizzei.Domain.Domains.Questions.Repositories;
using QZI.Quizzei.Domain.Domains.User.Service.Abstractions;

namespace QZI.Quizzei.Domain.Domains.Questions.Handlers
{
    public class AnswerCommandHandler : IRequestHandler<AnswerQuestionCommand, AnswerQuestionResponse>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IUserService _userService;

        public AnswerCommandHandler(IQuestionRepository questionRepository, IAnswerRepository answerRepository, IUserService userService)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _userService = userService;
        }

        public async Task<AnswerQuestionResponse> Handle(AnswerQuestionCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByEmail(request.Email);

            var question = await _questionRepository.GetQuestionById(request.Request.QuestionUuid);

            var selectedOption = question.Options.FirstOrDefault(x => x.QuestionOptionUuid == request.Request.OptionUuid);

            var newAnswer = Answer.CreateAnswer(selectedOption, user.UserUuid);

            await _answerRepository.AddAsync(newAnswer);

            return new AnswerQuestionResponse{CorrectAnswer = newAnswer.CorrectAnswer};
        }
    }
}
