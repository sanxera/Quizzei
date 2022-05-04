using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Quiz.Domain.Quiz.Handlers.Commands.Question;
using QZI.Quiz.Domain.Quiz.Handlers.Response.Question;
using QZI.Quiz.Domain.Quiz.Repositories;

namespace QZI.Quiz.Domain.Quiz.Handlers
{
    public class QuestionCommandHandler : IRequestHandler<CreateQuestionsCommand, CreateQuestionsResponse>
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public Task<CreateQuestionsResponse> Handle(CreateQuestionsCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            
            throw new NotImplementedException();
        }
    }
}
