using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QZI.Core.Controllers;

namespace QZI.Quiz.API.Controllers
{
    public class QuizInfoController : MainController
    {
        public async Task<IActionResult> CreateQuizInfo()
        {
            return Ok();
        }
    }
}
