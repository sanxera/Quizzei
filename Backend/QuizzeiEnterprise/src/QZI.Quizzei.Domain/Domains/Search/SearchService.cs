using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories;
using QZI.Quizzei.Domain.Domains.Search.Response;
using QZI.Quizzei.Domain.Domains.User.Entities;

namespace QZI.Quizzei.Domain.Domains.Search
{
    public class SearchService : ISearchService
    {
        private readonly IQuizInfoRepository _quizInfoRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public SearchService(IQuizInfoRepository quizInfoRepository, UserManager<ApplicationUser> userManager)
        {
            _quizInfoRepository = quizInfoRepository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<SearchResponse>> SearchByText(string text)
        {
            var quizzesInformation = await _quizInfoRepository.GetQuizzesByName(text);
            var users = await _userManager.Users.Where(x => EF.Functions.Like(x.Name, $"%{text}%")).ToListAsync();

            var searchResponse = users.Select(user => new SearchResponse(Guid.Parse(user.Id), user.Name, "User")).ToList();
            searchResponse.AddRange(quizzesInformation.Select(quiz => new SearchResponse(quiz.QuizInfoUuid, quiz.Title, "Quiz")));

            return searchResponse;
        }
    }
}
