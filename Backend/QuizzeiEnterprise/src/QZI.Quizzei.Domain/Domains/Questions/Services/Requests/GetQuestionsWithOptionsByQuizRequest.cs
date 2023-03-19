using System;

namespace QZI.Quizzei.Domain.Domains.Questions.Services.Requests;

public class GetQuestionsWithOptionsByQuizRequest
{
    public Guid QuizInfoUuid { get; set; }
}