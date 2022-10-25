using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Abstractions;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Requests.Information;

namespace QZI.Quizzei.API.Controllers
{
    //[Authorize]
    [Route("api/quizzes-info")]
    public class QuizInfoController : Controller
    {
        private readonly IQuizInformationService _quizInformationService;

        public QuizInfoController(IQuizInformationService quizInformationService)
        {
            _quizInformationService = quizInformationService;
        }

        [HttpPost("create-quiz-info")]
        public async Task<IActionResult> CreateQuizInfo([FromBody] CreateQuizInfoRequest request)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var result = await _quizInformationService.CreateQuizInformation(email, request);

            return Ok(result);
        }

        [HttpGet("get-all-by-user")]
        public async Task<IActionResult> GetQuizzesInfoByUser()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var result = await _quizInformationService.GetQuizzesInformationByUser(email);

            return Ok(result);
        }

        [HttpGet("get-all-by-different-users")]
        public async Task<IActionResult> GetQuizzesInfoByDifferentUsers()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var result = await _quizInformationService.GetQuizzesInformationByDifferentUser(email);

            return Ok(result);
        }

        [HttpGet("get-quizzes-by-category-from-different-users")]
        public async Task<IActionResult> GetQuizzesInfoSeparateByCategoriesFromDifferentUsers()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var result = await _quizInformationService.GetQuizzesInfoSeparateByCategoriesFromDifferentUsers(email);

            return Ok(result);
        }
    }
}
