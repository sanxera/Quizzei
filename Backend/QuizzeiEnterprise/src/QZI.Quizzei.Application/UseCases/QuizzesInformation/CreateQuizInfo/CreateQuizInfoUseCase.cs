using QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo.Interfaces;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.Shared.Services.Users.Interfaces;
using QZI.Quizzei.Application.Shared.UnitOfWork;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo.Models.Request;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo.Models.Response;

namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo;

public class CreateQuizInfoUseCase : ICreateQuizInfoUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserService _userService;
    private readonly IQuizInfoRepository _quizInfoRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CreateQuizInfoUseCase(IQuizInfoRepository quizInfoRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IUserService userService)
    {
        _quizInfoRepository = quizInfoRepository;
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _userService = userService;
    }

    public async Task<CreateQuizInfoResponse> CreateQuizInformation(string emailOwner, CreateQuizInfoRequest request)
    {
        var category = await _categoryRepository.GetCategoryById(request.CategoryId);
        var userResponse = await _userService.GetUserAsync(emailOwner);

        var quizInfo = QuizInformation.Create(request.Title, request.Description, userResponse.UserUuid, category.Id, request.ImageName);
        await _quizInfoRepository.AddAsync(quizInfo);

        await _unitOfWork.SaveChangesAsync();

        return CreateQuizInfoResponse.Create(quizInfo.QuizInfoUuid);
    }
}