using QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo.Interfaces;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Enums;
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
    private readonly IQuizAccessRepository _quizAccessRepository;

    public CreateQuizInfoUseCase(IQuizInfoRepository quizInfoRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IUserService userService, IQuizAccessRepository quizAccessRepository)
    {
        _quizInfoRepository = quizInfoRepository;
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _userService = userService;
        _quizAccessRepository = quizAccessRepository;
    }

    public async Task<CreateQuizInfoResponse> CreateQuizInformation(string emailOwner, CreateQuizInfoRequest request)
    {
        var category = await _categoryRepository.GetCategoryById(request.CategoryId);
        var userResponse = await _userService.GetUserAsync(emailOwner);

        var quizInfo = QuizInformation.Create(request.Title, request.Description, userResponse.UserUuid, category.Id, request.ImageName, request.PermissionType);
        await _quizInfoRepository.AddAsync(quizInfo);

        if (request.PermissionType != PermissionType.Pubic)
            await CreateQuizAccess(request, quizInfo);
        
        await _unitOfWork.SaveChangesAsync();

        return CreateQuizInfoResponse.Create(quizInfo.QuizInfoUuid);
    }

    private async Task CreateQuizAccess(CreateQuizInfoRequest request, QuizInformation quizInfo)
    {
        var quizAccess = QuizAccess.Create(quizInfo.QuizInfoUuid, request.QuizAccessRequest.InitialDate,
            request.QuizAccessRequest.EndDate, request.QuizAccessRequest.AccessCode);

        await _quizAccessRepository.AddAsync(quizAccess);
    }
}