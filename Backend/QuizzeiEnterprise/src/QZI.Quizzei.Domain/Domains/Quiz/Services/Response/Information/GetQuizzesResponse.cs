﻿using System.Collections.Generic;

namespace QZI.Quizzei.Domain.Domains.Quiz.Services.Response.Information;

public class GetQuizzesResponse
{
    public IList<QuizInfoResponse> QuizzesInfoDto { get; set; } = new List<QuizInfoResponse>();
}