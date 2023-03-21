using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Application.Shared.Entities;
using QZI.Quizzei.Application.Shared.Repositories;
using QZI.Quizzei.Application.UseCases.Search.SearchByText.Interfaces;
using QZI.Quizzei.Application.UseCases.Search.SearchByText.Response;

namespace QZI.Quizzei.Application.UseCases.Search.SearchByText;

public class SearchByTextUseCase : ISearchByTextUseCase
{
    private readonly IQuizInfoRepository _quizInfoRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public SearchByTextUseCase(IQuizInfoRepository quizInfoRepository, UserManager<ApplicationUser> userManager)
    {
        _quizInfoRepository = quizInfoRepository;
        _userManager = userManager;
    }

    public async Task<SearchByTextResponse> ExecuteAsync(string text)
    {
        var searchResponse = new SearchByTextResponse();
        var quizzesInformation = await _quizInfoRepository.GetQuizzesByTitle(text);
        var users = await _userManager.Users.Where(x => EF.Functions.Like(x.Name, $"%{text}%")).ToListAsync();

        AddFoundUsersToResponse(users, searchResponse);
        AddFoundQuizzesToResponse(quizzesInformation, searchResponse);

        return searchResponse;
    }

    private static void AddFoundQuizzesToResponse(IEnumerable<QuizInformation> quizzesInformation, SearchByTextResponse searchByTextResponse)
    {
        foreach (var quiz in quizzesInformation)
        {
            var searchQuiz = new SearchQuiz
            {
                Title = quiz.Title,
                QuizUuid = quiz.QuizInfoUuid
            };

            searchByTextResponse.Quizzes.Add(searchQuiz);
        }
    }

    private static void AddFoundUsersToResponse(List<ApplicationUser> users, SearchByTextResponse searchByTextResponse)
    {
        foreach (var user in users)
        {
            var userSearch = new SearchUser
            {
                Name = user.Name,
                UserUuid = Guid.Parse(user.Id)
            };

            searchByTextResponse.Users.Add(userSearch);
        }
    }
}