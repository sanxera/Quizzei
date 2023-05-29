using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Enums;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.Services.Amazon.Interfaces;
using QZI.Quizzei.Application.Shared.UnitOfWork;
using QZI.Quizzei.Application.UseCases.Questions.UpdateQuestionsUseCase.Interfaces;
using QZI.Quizzei.Application.UseCases.Questions.UpdateQuestionsUseCase.Models.Request;

namespace QZI.Quizzei.Application.UseCases.Questions.UpdateQuestionsUseCase;

public class UpdateQuestionsUseCase : IUpdateQuestionsUseCase
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuestionOptionRepository _questionOptionRepository;
    private readonly IQuestionImageRepository _questionImageRepository;
    private readonly IAmazonService _amazonService;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateQuestionsUseCase(IQuestionRepository questionRepository, IQuestionOptionRepository questionOptionRepository, IUnitOfWork unitOfWork, IAmazonService amazonService, IQuestionImageRepository questionImageRepository)
    {
        _questionRepository = questionRepository;
        _questionOptionRepository = questionOptionRepository;
        _unitOfWork = unitOfWork;
        _amazonService = amazonService;
        _questionImageRepository = questionImageRepository;
    }

    public async Task ExecuteAsync(UpdateQuestionsRequest request)
    {
        foreach (var questionRequest in request.Questions)
        {
            switch (questionRequest.Action)
            {
                case ActionEnum.Create:
                    await CreateQuestionsWithOptions(request.QuizInfoUuid!.Value, questionRequest);
                    break;

                case ActionEnum.Update:
                    await UpdateQuestion(questionRequest);
                    break;

                case ActionEnum.Delete:
                    await DeleteQuestion(questionRequest);
                    break;

                case ActionEnum.NonAction:
                    continue;

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

        foreach (var questionRequestImage in questionRequest.Images)
        {
            question.Images.Add(QuestionImage.Create(questionRequestImage.ImageName));

            var oldQuestionImage = await _questionImageRepository.GetQuestionImageById(questionRequestImage.QuestionImageUuid);
            _questionImageRepository.DeleteById(oldQuestionImage!.QuestionImageUuid);
        }

        await _questionRepository.AddAsync(question);
    }

    private async Task UpdateQuestion(UpdateQuestions questionRequest)
    {
        var question = await _questionRepository.GetQuestionById(questionRequest.QuestionUuid);
        question.Description = questionRequest.Description;

        foreach (var questionImage in question.Images)
        {
            var oldQuestionImage = await _questionImageRepository.GetQuestionImageById(questionImage.QuestionImageUuid);
            _questionImageRepository.DeleteById(oldQuestionImage!.QuestionImageUuid);
        }

        foreach (var questionRequestImage in questionRequest.Images)
        {
            question.Images.Add(QuestionImage.Create(questionRequestImage.ImageName));
        }

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

                case ActionEnum.NonAction:
                    continue;

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

        foreach (var image in question.Images)
        {
            _questionImageRepository.Delete(image);
        }

        _questionRepository.Delete(question);
    }

    private void CreateOption(Question? question, UpdateOptions option)
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
}