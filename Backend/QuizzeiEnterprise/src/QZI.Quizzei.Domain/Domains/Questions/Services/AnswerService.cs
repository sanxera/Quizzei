using System;
using System.Linq;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Abstractions.UnitOfWork;
using QZI.Quizzei.Domain.Domains.Questions.Entities;
using QZI.Quizzei.Domain.Domains.Questions.Repositories;
using QZI.Quizzei.Domain.Domains.Questions.Services.Abstractions;
using QZI.Quizzei.Domain.Domains.Questions.Services.Requests;
using QZI.Quizzei.Domain.Domains.Questions.Services.Responses;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Entities.Enums;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories;
using QZI.Quizzei.Domain.Domains.User.Service.Abstractions;
using QZI.Quizzei.Domain.Domains.User.Service.Response;
using QZI.Quizzei.Domain.Exceptions;

namespace QZI.Quizzei.Domain.Domains.Questions.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IQuizProcessRepository _quizProcessRepository;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public AnswerService(IQuestionRepository questionRepository, IAnswerRepository answerRepository, IUserService userService, IUnitOfWork unitOfWork, IQuizProcessRepository quizProcessRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _userService = userService;
            _unitOfWork = unitOfWork;
            _quizProcessRepository = quizProcessRepository;
        }

        public async Task<AnswerQuestionResponse> AnswerQuestion(string emailOwner, Guid quizProcessUuid, AnswerQuestionRequest request)
        {
            var user = await _userService.GetUserByEmail(emailOwner);
            var quizProcess = await _quizProcessRepository.GetQuizProcessById(quizProcessUuid);
            var correctAnswers = 0;

            foreach (var answer in request.Answers)
            {
                var question = await _questionRepository.GetQuestionById(answer.QuestionUuid);

                ValidateAnswer(user, question, quizProcess);

                var selectedOption = question.Options.FirstOrDefault(x => x.QuestionOptionUuid == answer.OptionUuid);

                var newAnswer = Answer.CreateAnswer(selectedOption!.QuestionOptionUuid, question.QuestionUuid, quizProcess.QuizProcessUuid, user.Id, selectedOption.IsCorrect);

                await _answerRepository.AddAsync(newAnswer);

                if (selectedOption.IsCorrect)
                    correctAnswers++;
            }

            quizProcess.Status = QuizProcessStatus.Finished;

            await _unitOfWork.SaveChangesAsync();
            return new AnswerQuestionResponse { CorrectAnswers = correctAnswers, TotalQuestions = request.Answers.Count };
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
