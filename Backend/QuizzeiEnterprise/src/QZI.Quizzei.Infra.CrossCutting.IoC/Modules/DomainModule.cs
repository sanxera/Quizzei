using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QZI.Quizzei.Domain.Configuration;
using QZI.Quizzei.Domain.Domains.Categories.Service;
using QZI.Quizzei.Domain.Domains.Categories.Service.Abstractions;
using QZI.Quizzei.Domain.Domains.Files;
using QZI.Quizzei.Domain.Domains.Files.Abstractions;
using QZI.Quizzei.Domain.Domains.Files.Helpers;
using QZI.Quizzei.Domain.Domains.Questions.Services;
using QZI.Quizzei.Domain.Domains.Questions.Services.Abstractions;
using QZI.Quizzei.Domain.Domains.Quiz.Services;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Abstractions;
using QZI.Quizzei.Domain.Domains.Search;
using QZI.Quizzei.Domain.Domains.User.Service;
using QZI.Quizzei.Domain.Domains.User.Service.Abstractions;
using QZI.Quizzei.Domain.Shared.Interfaces;
using QZI.Quizzei.Domain.Shared.Services;

namespace QZI.Quizzei.Infra.CrossCutting.IoC.Modules;

public static class DomainModule
{
    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IAnswerService, AnswerService>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IQuizProcessService, QuizProcessService>();
        services.AddScoped<IQuizInformationService, QuizInformationService>();
        services.AddScoped<ISearchService, SearchService>();
        services.AddScoped<IFilesService, FilesService>();

        services.AddScoped<IOcrService, OcrService>();
        services.AddScoped<ITokenSplitService, TokenSplitService>();
        services.AddScoped<IReadPdfService, ReadPdfService>();

        services.AddScoped<IAmazonService, AmazonService>();
        services.AddScoped<IImageService, ImageService>();

        services.AddSingleton(configuration.GetSection("AwsConfiguration").Get<AwsConfiguration>()!);
    }
}