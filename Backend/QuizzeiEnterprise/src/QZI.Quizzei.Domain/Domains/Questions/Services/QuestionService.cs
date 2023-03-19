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

namespace QZI.Quizzei.Domain.Domains.Questions.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuestionOptionRepository _questionOptionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public QuestionService(IUnitOfWork unitOfWork, IQuestionRepository questionRepository, IQuestionOptionRepository questionOptionRepository)
    {
        _unitOfWork = unitOfWork;
        _questionRepository = questionRepository;
        _questionOptionRepository = questionOptionRepository;
    }

    public async Task<GetQuestionsWithOptionsByQuizResponse> GetQuestionWithOptionsByQuizInfo(Guid quizInfo)
    {
        var questions = await _questionRepository.GetQuestionsByQuizInfo(quizInfo);

        return CreateQuestionResponse(questions);
    }

    public async Task UpdateQuestions(Guid quizInfoUuid, UpdateQuestionsWithOptionsRequest request)
    {
        foreach (var questionRequest in request.Questions)
        {
            switch (questionRequest.Action)
            {
                case ActionEnum.Create:
                    await CreateQuestionsWithOptions(quizInfoUuid, questionRequest);
                    break;

                case ActionEnum.Update:
                    await UpdateQuestion(questionRequest);
                    break;

                case ActionEnum.Delete:
                    await DeleteQuestion(questionRequest);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        await _unitOfWork.SaveChangesAsync();
    }


    private async Task CreateQuestionsWithOptions(Guid quizInfoUuid, UpdateQuestions questionRequest)
    {
        var question = Question.CreateQuestion(questionRequest.Description, quizInfoUuid);
        question.Options = QuestionOption.CreateAnyOptions(questionRequest.Options.ToList());

        await _questionRepository.AddAsync(question);
    }

    private async Task UpdateQuestion(UpdateQuestions questionRequest)
    {
        var question = await _questionRepository.GetQuestionById(questionRequest.QuestionUuid);

        question.Description = questionRequest.Description;
        foreach (var optionRequest in questionRequest.Options)
        {
            switch (optionRequest.Action)
            {
                case ActionEnum.Create:
                    CreateOption(question, optionRequest);
                    break;

                case ActionEnum.Update:
                    await UpdateOption(optionRequest);
                    break;

                case ActionEnum.Delete:
                    await DeleteOption(optionRequest);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private async Task DeleteQuestion(UpdateQuestions questionRequest)
    {
        var question = await _questionRepository.GetQuestionById(questionRequest.QuestionUuid);

        foreach (var option in question.Options)
        {
            _questionOptionRepository.Delete(option);
        }

        _questionRepository.Delete(question);
    }

    private void CreateOption(Question question, UpdateOptions option)
    {
        var newOption = new QuestionOption(option.Description, option.IsCorrect, question.QuestionUuid, question);

        question.Options.Add(newOption);

        _questionRepository.Update(question);
    }

    private async Task UpdateOption(UpdateOptions optionRequest)
    {
        var option = await _questionOptionRepository.GetQuestionOptionById(optionRequest.OptionUuid);

        option.Description = optionRequest.Description;
        option.IsCorrect = optionRequest.IsCorrect;

        _questionOptionRepository.Update(option);
    }

    private async Task DeleteOption(UpdateOptions optionRequest)
    {
        var option = await _questionOptionRepository.GetQuestionOptionById(optionRequest.OptionUuid);

        _questionOptionRepository.Delete(option);
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
            .Select(option => new QuestionOptionResponse { OptionDescription = option.Description, OptionUuid = option.QuestionOptionUuid,  IsCorrect = option.IsCorrect})
            .ToList();
    }
}