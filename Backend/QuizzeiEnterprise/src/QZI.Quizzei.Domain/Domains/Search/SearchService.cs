using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
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

        public async Task<SearchResponse> SearchByText(string text)
        {
            var searchResponse = new SearchResponse();
            var quizzesInformation = await _quizInfoRepository.GetQuizzesByTitle(text);
            var users = await _userManager.Users.Where(x => EF.Functions.Like(x.Name, $"%{text}%")).ToListAsync();

            AddFoundUsersToResponse(users, searchResponse);
            AddFoundQuizzesToResponse(quizzesInformation, searchResponse);

            return searchResponse;
        }

        private static void AddFoundQuizzesToResponse(IEnumerable<QuizInformation> quizzesInformation, SearchResponse searchResponse)
        {
            foreach (var quiz in quizzesInformation)
            {
                var searchQuiz = new SearchQuiz
                {
                    Title = quiz.Title,
                    QuizUuid = quiz.QuizInfoUuid
                };

                searchResponse.Quizzes.Add(searchQuiz);
            }
        }

        private static void AddFoundUsersToResponse(List<ApplicationUser> users, SearchResponse searchResponse)
        {
            foreach (var user in users)
            {
                var userSearch = new SearchUser
                {
                    Name = user.Name,
                    UserUuid = Guid.Parse(user.Id)
                };

                searchResponse.Users.Add(userSearch);
            }
        }
    }
}
