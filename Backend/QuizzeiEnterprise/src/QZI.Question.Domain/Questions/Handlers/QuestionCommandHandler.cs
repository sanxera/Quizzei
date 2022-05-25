using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Question.Domain.Questions.Entities;
using QZI.Question.Domain.Questions.Exceptions;
using QZI.Question.Domain.Questions.Handlers.Commands;
using QZI.Question.Domain.Questions.Handlers.Requests;
using QZI.Question.Domain.Questions.Handlers.Responses;
using QZI.Question.Domain.Questions.Repositories;
using QZI.Question.Domain.Questions.UnitOfWork;

namespace QZI.Question.Domain.Questions.Handlers
{
    public class QuestionCommandHandler : IRequestHandler<CreateQuestionsCommand, CreateQuestionsResponse>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionCommandHandler(IUnitOfWork unitOfWork, IQuestionRepository questionRepository)
        {
            _unitOfWork = unitOfWork;
            _questionRepository = questionRepository;
        }

        public async Task<CreateQuestionsResponse> Handle(CreateQuestionsCommand command, CancellationToken cancellationToken)
        {
            await CreateQuestions(command.QuizInfoUuid, command.Request);

            await _unitOfWork.SaveChangesAsync();

            return new CreateQuestionsResponse { QuizInfoUuid = command.QuizInfoUuid, Created = true };
        }

        private async Task CreateQuestions(Guid quizUuid, CreateQuestionsRequest request)
        {
            try
            {
                foreach (var questionRequest in request.Questions)
                {
                    var question = Entities.Question.CreateQuestion(questionRequest.Description, quizUuid);
                    question.Options = QuestionOption.CreateAnyOptions(questionRequest.Options.ToList());

                    await _questionRepository.AddAsync(question);
                }
            }
            catch (Exception ex)
            {
                throw new CreateQuestionsException("Error to create questions for quiz", ex);
            }
        }
    }
}
