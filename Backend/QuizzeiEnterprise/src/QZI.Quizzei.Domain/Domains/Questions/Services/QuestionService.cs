using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Abstractions.UnitOfWork;
using QZI.Quizzei.Domain.Domains.Questions.Entities;
using QZI.Quizzei.Domain.Domains.Questions.Repositories;
using QZI.Quizzei.Domain.Domains.Questions.Services.Abstractions;
using QZI.Quizzei.Domain.Domains.Questions.Services.Requests;
using QZI.Quizzei.Domain.Domains.Questions.Services.Responses;

namespace QZI.Quizzei.Domain.Domains.Questions.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(IUnitOfWork unitOfWork, IQuestionRepository questionRepository)
        {
            _unitOfWork = unitOfWork;
            _questionRepository = questionRepository;
        }

        public async Task<CreateQuestionsResponse> CreateQuestions(Guid quizInfoUuid, CreateQuestionsRequest request)
        {
            foreach (var questionRequest in request.Questions)
            {
                var question = Question.CreateQuestion(questionRequest.Description, quizInfoUuid);
                question.Options = QuestionOption.CreateAnyOptions(questionRequest.Options.ToList());

                await _questionRepository.AddAsync(question);
            }

            await _unitOfWork.SaveChangesAsync();
            return new CreateQuestionsResponse { Created = true };
        }

        public async Task<GetQuestionsWithOptionsByQuizResponse> GetQuestionWithOptionsByQuizInfo(Guid quizInfo)
        {
            var questions = await _questionRepository.GetQuestionsByQuizInfo(quizInfo);

            return CreateQuestionResponse(questions);
        }

        private static GetQuestionsWithOptionsByQuizResponse CreateQuestionResponse(IEnumerable<Question> questions)
        {
            var questionToReturn = new GetQuestionsWithOptionsByQuizResponse();

            foreach (var question in questions)
            {
                var questionDto = new QuestionResponse
                {
                    QuestionDescription = question.Description,
                    QuestionUuid = question.QuestionUuid,
                    Options = CreateOptionsResponse(question)
                };

                questionToReturn.Questions.Add(questionDto);
            }

            return questionToReturn;
        }

        private static IList<QuestionOptionResponse> CreateOptionsResponse(Question question)
        {
            return question.Options
                    .Select(option => new QuestionOptionResponse { OptionDescription = option.Description, OptionUuid = option.QuestionOptionUuid })
                    .ToList();
        }
    }
}
