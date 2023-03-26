using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoByUser.Interfaces;
using QZI.Quizzei.Application.UseCases.QuizzesInformation.GetQuizzesInfoByUser.Models.Request;

namespace QZI.Quizzei.API.Controllers.UseCases.QuizInformation.GetQuizzesInfoByUser;

[Route("api/quizzes-info")]
public class QuizInfoController : MainController
{
    private readonly IGetQuizzesInfoByUserUseCase _useCase;

    public QuizInfoController(IGetQuizzesInfoByUserUseCase useCase, IHttpContextAccessor contextAccessor) : base(contextAccessor)
    {
        _useCase = useCase;
    }

    [HttpGet("get-all-by-user")]
    public async Task<IActionResult> GetQuizzesInfoByUser()
    {
        var email = ReadEmailFromToken();
        var result = await _useCase.ExecuteAsync(new GetQuizzesInfoByUserRequest{Email = email});

        return Ok(result);
    }


    [HttpGet("get-quizzes-from-user-id/{userUuid:guid}")]
    public async Task<IActionResult> GetQuizzesInfoFromUserByEmail(Guid userUuid)
    {
        var result = await _useCase.ExecuteAsync(new GetQuizzesInfoByUserRequest{UserUuid = userUuid});

        return Ok(result);
    }
}