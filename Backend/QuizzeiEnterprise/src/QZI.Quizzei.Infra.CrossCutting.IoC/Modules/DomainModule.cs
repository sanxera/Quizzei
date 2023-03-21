using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QZI.Quizzei.Application.Shared.Services.Amazon;
using QZI.Quizzei.Application.Shared.Services.Amazon.Configuration;
using QZI.Quizzei.Application.Shared.Services.Amazon.Interfaces;
using QZI.Quizzei.Application.Shared.Services.Images;
using QZI.Quizzei.Application.Shared.Services.Images.Interfaces;
using QZI.Quizzei.Application.Shared.Services.Users;
using QZI.Quizzei.Application.Shared.Services.Users.Interfaces;
using QZI.Quizzei.Application.UseCases.Answers.AnswerQuiz;
using QZI.Quizzei.Application.UseCases.Answers.AnswerQuiz.Interfaces;
using QZI.Quizzei.Application.UseCases.Categories.CreateCategory;
using QZI.Quizzei.Application.UseCases.Categories.CreateCategory.Interfaces;
using QZI.Quizzei.Application.UseCases.Categories.GetAllCategories;
using QZI.Quizzei.Application.UseCases.Categories.GetAllCategories.Interfaces;
using QZI.Quizzei.Application.UseCases.Categories.GetCategoryById;
using QZI.Quizzei.Application.UseCases.Categories.GetCategoryById.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.DownloadFile;
using QZI.Quizzei.Application.UseCases.Files.DownloadFile.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.GetDefaultImages;
using QZI.Quizzei.Application.UseCases.Files.GetDefaultImages.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.GetFilesFromQuiz;
using QZI.Quizzei.Application.UseCases.Files.GetFilesFromQuiz.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.GetRandomFiles;
using QZI.Quizzei.Application.UseCases.Files.GetRandomFiles.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.ReadPdf;
using QZI.Quizzei.Application.UseCases.Files.ReadPdf.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.ReadPdf.Services.Ocr;
using QZI.Quizzei.Application.UseCases.Files.ReadPdf.Services.Ocr.Interfaces;
using QZI.Quizzei.Application.UseCases.Files.UploadFile;
using QZI.Quizzei.Application.UseCases.Files.UploadFile.Interfaces;
using QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz;
using QZI.Quizzei.Application.UseCases.Questions.GetQuestionsByQuiz.Interfaces;
using QZI.Quizzei.Application.UseCases.Questions.UpdateQuestionsUseCase;
using QZI.Quizzei.Application.UseCases.Questions.UpdateQuestionsUseCase.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.CreateQuizInfo.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoByUser;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoByUser.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoForUser;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoForUser.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoHistory;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoHistory.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoPerCategories;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoPerCategories.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.UpdateQuizInfo;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.UpdateQuizInfo.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.RatingQuiz;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.RatingQuiz.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.StartQuizProcess;
using QZI.Quizzei.Application.UseCases.QuizzesProcess.StartQuizProcess.Interfaces;
using QZI.Quizzei.Application.UseCases.Search.SearchByText;
using QZI.Quizzei.Application.UseCases.Search.SearchByText.Interfaces;
using QZI.Quizzei.Application.UseCases.Users.CreateRole;
using QZI.Quizzei.Application.UseCases.Users.CreateRole.Interfaces;
using QZI.Quizzei.Application.UseCases.Users.CreateUser;
using QZI.Quizzei.Application.UseCases.Users.CreateUser.Interfaces;

namespace QZI.Quizzei.Infra.CrossCutting.IoC.Modules;

public static class DomainModule
{
    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IOcrService, OcrService>();
        services.AddScoped<ITokenSplitService, TokenSplitService>();

        services.AddScoped<IAmazonService, AmazonService>();
        services.AddScoped<IImageService, ImageService>();

        services.AddSingleton(configuration.GetSection("AwsConfiguration").Get<AwsConfiguration>()!);

        services.AddScoped<IAnswerQuizUseCase, AnswerQuizUseCase>();
        services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
        services.AddScoped<IGetAllCategoriesUseCase, GetAllCategoriesUseCase>();
        services.AddScoped<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
        services.AddScoped<IDownloadFileUseCase, DownloadFileUseCase>();
        services.AddScoped<IGetFilesFromQuizUseCase, GetFilesFromQuizUseCase>();
        services.AddScoped<IGetRandomFilesUseCase, GetRandomFilesUseCase>();
        services.AddScoped<IReadPdfUseCase, ReadPdfUseCase>();
        services.AddScoped<IUploadFileUseCase, UploadFileUseCase>();
        services.AddScoped<ICreateQuizInfoUseCase, CreateQuizInfoUseCase>();
        services.AddScoped<IGetQuizzesInfoByUserUseCase, GetQuizzesInfoByUserUseCase>();
        services.AddScoped<IGetQuizzesInfoForUserUseCase, GetQuizzesInfoForUserUseCase>();
        services.AddScoped<IGetQuizzesInfoHistoryUseCase, GetQuizzesInfoHistoryUseCase>();
        services.AddScoped<IGetQuizzesInfoPerCategoriesUseCase, GetQuizzesInfoPerCategoriesUseCase>();
        services.AddScoped<IUpdateQuizInfoUseCase, UpdateQuizInfoUseCase>();
        services.AddScoped<IRatingQuizUseCase, RatingQuizUseCase>();
        services.AddScoped<IStartQuizProcessUseCase, StartQuizProcessUseCase>();
        services.AddScoped<ISearchByTextUseCase, SearchByTextUseCase>();
        services.AddScoped<ICreateRoleUseCase, CreateRoleUseCase>();
        services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        services.AddScoped<IGetDefaultImagesUseCase, GetDefaultImagesUseCase>();
        services.AddScoped<IUpdateQuestionsUseCase, UpdateQuestionsUseCase>();
        services.AddScoped<IGetQuestionsByQuizUseCase, GetQuestionsByQuizUseCase>();
    }
}