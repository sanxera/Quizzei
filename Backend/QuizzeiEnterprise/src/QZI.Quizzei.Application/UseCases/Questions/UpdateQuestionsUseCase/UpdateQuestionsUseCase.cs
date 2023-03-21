using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.UnitOfWork;
using QZI.Quizzei.Application.UseCases.Questions.UpdateQuestionsUseCase.Interfaces;
using QZI.Quizzei.Application.UseCases.Questions.UpdateQuestionsUseCase.Models.Request;

namespace QZI.Quizzei.Application.UseCases.Questions.UpdateQuestionsUseCase;

public class UpdateQuestionsUseCase : IUpdateQuestionsUseCase
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IQuestionOptionRepository _questionOptionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateQuestionsUseCase(IQuestionRepository questionRepository, IQuestionOptionRepository questionOptionRepository, IUnitOfWork unitOfWork)
    {
        _questionRepository = questionRepository;
        _questionOptionRepository = questionOptionRepository;
        _unitOfWork = unitOfWork;
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
}