using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Domain.Quiz.Exceptions;
using QZI.Quiz.Domain.Quiz.Handlers.Commands.Question;
using QZI.Quiz.Domain.Quiz.Handlers.Requests.Questions;
using QZI.Quiz.Domain.Quiz.Handlers.Response.Question;
using QZI.Quiz.Domain.Quiz.Repositories;
using QZI.Quiz.Domain.Quiz.UnitOfWork;

namespace QZI.Quiz.Domain.Quiz.Handlers
{
    public class QuestionCommandHandler : IRequestHandler<CreateQuestionsCommand, CreateQuestionsResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuizInfoRepository _quizInfoRepository;
        private readonly IQuestionRepository _questionRepository;

        public QuestionCommandHandler(IQuestionRepository questionRepository, IQuizInfoRepository quizInfoRepository, IUnitOfWork unitOfWork)
        {
            _questionRepository = questionRepository;
            _quizInfoRepository = quizInfoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateQuestionsResponse> Handle(CreateQuestionsCommand command, CancellationToken cancellationToken)
        {
            var quizInfo = await GetQuizInfo(command.Request.QuizUuid);

            CreateNewQuestions(quizInfo, command.Request);

            _quizInfoRepository.Update(quizInfo);

            await _unitOfWork.SaveChangesAsync();

            return new CreateQuestionsResponse { Created = true };
        }

        private async Task<QuizInfo> GetQuizInfo(Guid quizUuid)
        {
            var quizInfo = await _quizInfoRepository.GetQuizInfoById(quizUuid);

            if (quizInfo == null)
                throw new NotFoundQuizInfoException("Quiz Information not found !");

            return quizInfo;
        }

        private static void CreateNewQuestions(QuizInfo quizInfo, CreateQuestionsRequest request)
        {
            try
            {
                foreach (var questionRequest in request.Questions)
                {
                    var question = Question.CreateQuestionWithOptions(questionRequest.Description);
                    question.Options = QuestionOption.CreateAnyOptions(questionRequest.Options.ToList());

                    quizInfo.Questions.Add(question);
                }
            }
            catch (Exception ex)
            {
                throw new CreateQuestionsException("Error to create questions for quiz", ex);
            }
        }
    }
}
