using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Quiz.Domain.Quiz.Handlers.Commands.Question;
using QZI.Quiz.Domain.Quiz.Handlers.Requests.Questions;
using QZI.Quiz.Domain.Quiz.Handlers.Response.Question;
using QZI.Quiz.Domain.Quiz.Repositories;

namespace QZI.Quiz.Domain.Quiz.Handlers
{
    public class QuestionCommandHandler : IRequestHandler<CreateQuestionsCommand, CreateQuestionsResponse>
    {
        private readonly IQuizInfoRepository _quizInfoRepository;
        private readonly IQuestionRepository _questionRepository;

        public QuestionCommandHandler(IQuestionRepository questionRepository, IQuizInfoRepository quizInfoRepository)
        {
            _questionRepository = questionRepository;
            _quizInfoRepository = quizInfoRepository;
        }

        public Task<CreateQuestionsResponse> Handle(CreateQuestionsCommand request, CancellationToken cancellationToken)
        {
            request.Validate();
            
            throw new NotImplementedException();
        }

        private void ValidateQuizInfo()
        {

        }

        private void CreateNewQuestions(CreateQuestionsRequest request)
        {

        }
    }
}
