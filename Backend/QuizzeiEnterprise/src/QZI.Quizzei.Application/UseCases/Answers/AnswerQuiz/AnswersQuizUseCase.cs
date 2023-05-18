using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Enums;
using QZI.Quizzei.Application.Shared.Exceptions;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.Services.Users.Interfaces;
using QZI.Quizzei.Application.Shared.Services.Users.Response;
using QZI.Quizzei.Application.Shared.UnitOfWork;
using QZI.Quizzei.Application.UseCases.Answers.AnswerQuiz.Interfaces;
using QZI.Quizzei.Application.UseCases.Answers.AnswerQuiz.Models.Requests;
using QZI.Quizzei.Application.UseCases.Answers.AnswerQuiz.Models.Response;

namespace QZI.Quizzei.Application.UseCases.Answers.AnswerQuiz;

public class AnswerQuizUseCase : IAnswerQuizUseCase
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IAnswerRepository _answerRepository;
    private readonly IQuizProcessRepository _quizProcessRepository;
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;

    public AnswerQuizUseCase(IQuestionRepository questionRepository, IAnswerRepository answerRepository, IUserService userService, IUnitOfWork unitOfWork, IQuizProcessRepository quizProcessRepository)
    {
        _questionRepository = questionRepository;
        _answerRepository = answerRepository;
        _userService = userService;
        _unitOfWork = unitOfWork;
        _quizProcessRepository = quizProcessRepository;
    }

    public async Task<AnswerQuizResponse> ExecuteAsync(string emailOwner, Guid quizProcessUuid, AnswerQuizRequest request)
    {
        var user = await _userService.GetUserAsync(emailOwner);
        var quizProcess = await _quizProcessRepository.GetQuizProcessById(quizProcessUuid);
        var correctAnswers = 0;

        foreach (var answer in request.Answers)
        {
            var question = await _questionRepository.GetQuestionById(answer.QuestionUuid);

            ValidateAnswer(user, question, quizProcess);

            var selectedOption = question.Options.FirstOrDefault(x => x.QuestionOptionUuid == answer.OptionUuid);

            var newAnswer = Answer.CreateAnswer(selectedOption!.QuestionOptionUuid, question.QuestionUuid, quizProcess.QuizProcessUuid, user.UserUuid, selectedOption.IsCorrect);

            await _answerRepository.AddAsync(newAnswer);

            if (selectedOption.IsCorrect)
                correctAnswers++;
        }

        quizProcess.Status = QuizProcessStatus.Finished;
        await _unitOfWork.SaveChangesAsync();

        return new AnswerQuizResponse { CorrectAnswers = correctAnswers, TotalQuestions = request.Answers.Count };
    }

    private static void ValidateAnswer(GetUserResponse user, Question? question, QuizProcess quizProcess)
    {
        if (user is null || question is null || quizProcess is null)
        {
            throw new GenericException("Answer is invalid in this quiz process !");
        }
    }
}