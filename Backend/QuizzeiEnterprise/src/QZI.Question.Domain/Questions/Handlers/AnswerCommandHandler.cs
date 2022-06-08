using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Question.Domain.Questions.Acl.Interface;
using QZI.Question.Domain.Questions.Entities;
using QZI.Question.Domain.Questions.Handlers.Commands;
using QZI.Question.Domain.Questions.Handlers.Responses;
using QZI.Question.Domain.Questions.Repositories;

namespace QZI.Question.Domain.Questions.Handlers
{
    public class AnswerCommandHandler : IRequestHandler<AnswerQuestionCommand, AnswerQuestionResponse>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IUserServiceAcl _userServiceAcl;

        public AnswerCommandHandler(IQuestionRepository questionRepository, IAnswerRepository answerRepository, IUserServiceAcl userServiceAcl)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _userServiceAcl = userServiceAcl;
        }

        public async Task<AnswerQuestionResponse> Handle(AnswerQuestionCommand request, CancellationToken cancellationToken)
        {
            var user = await _userServiceAcl.GetUserIdByEmail(request.Email);

            var question = await _questionRepository.GetQuestionById(request.Request.QuestionUuid);

            var selectedOption = question.Options.FirstOrDefault(x => x.QuestionOptionUuid == request.Request.OptionUuid);

            var newAnswer = Answer.CreateAnswer(selectedOption, user.Id);

            await _answerRepository.AddAsync(newAnswer);

            return new AnswerQuestionResponse{CorrectAnswer = newAnswer.CorrectAnswer};
        }
    }
}
