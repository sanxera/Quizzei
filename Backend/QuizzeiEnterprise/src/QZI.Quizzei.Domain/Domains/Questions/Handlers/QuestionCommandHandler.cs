using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QZI.Quizzei.Domain.Abstractions.UnitOfWork;
using QZI.Quizzei.Domain.Domains.Questions.Entities;
using QZI.Quizzei.Domain.Domains.Questions.Handlers.Commands;
using QZI.Quizzei.Domain.Domains.Questions.Handlers.Requests;
using QZI.Quizzei.Domain.Domains.Questions.Handlers.Responses;
using QZI.Quizzei.Domain.Domains.Questions.Repositories;
using QZI.Quizzei.Domain.Exceptions;

namespace QZI.Quizzei.Domain.Domains.Questions.Handlers
{
    public class QuestionCommandHandler : 
        IRequestHandler<CreateQuestionsCommand, CreateQuestionsResponse>,
        IRequestHandler<GetQuestionsWithOptionsByQuizCommand, GetQuestionsWithOptionsByQuizResponse>
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

            return new CreateQuestionsResponse { Created = true };
        }

        public async Task<GetQuestionsWithOptionsByQuizResponse> Handle(GetQuestionsWithOptionsByQuizCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var questions = await _questionRepository.GetQuestionsByQuizInfo(command.Request.QuizInfoUuid);

                return CreateQuestionResponse(questions);
            }
            catch (Exception ex)
            {
                throw new GetQuestionsException("Error to get questions for quiz", ex);
            }
        }

        private async Task CreateQuestions(Guid quizUuid, CreateQuestionsRequest request)
        {
            try
            {
                foreach (var questionRequest in request.Questions)
                {
                    var question = Question.CreateQuestion(questionRequest.Description, quizUuid);
                    question.Options = QuestionOption.CreateAnyOptions(questionRequest.Options.ToList());

                    await _questionRepository.AddAsync(question);
                }
            }
            catch (Exception ex)
            {
                throw new CreateQuestionsException("Error to create questions for quiz", ex);
            }
        }

        private static GetQuestionsWithOptionsByQuizResponse CreateQuestionResponse(IEnumerable<Question> questions)
        {
            var questionToReturn = new GetQuestionsWithOptionsByQuizResponse();

            foreach (var question in questions)
            {
                var questionDto = new QuestionResponse
                {
                    QuestionDescription = question.Description, QuestionUuid = question.QuestionUuid,
                    Options = CreateOptionsResponse(question)
                };

                questionToReturn.Questions.Add(questionDto);
            }

            return questionToReturn;
        }

        private static IList<QuestionOptionResponse> CreateOptionsResponse(Question question)
        {
            return question.Options
                    .Select(option => new QuestionOptionResponse {OptionDescription = option.Description, OptionUuid = option.QuestionOptionUuid})
                    .ToList();
        }
    }
}
