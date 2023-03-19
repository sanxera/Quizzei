using System;
using System.Collections.Generic;

namespace QZI.Quizzei.Domain.Domains.Quiz.Services.Response.Information;

public class GetQuizzesHistoryFromUserResponse
{
    public Guid UserUuid { get; set; }
    public IList<QuizHistoryInformation> QuizzesHistoryInformation { get; set; } = new List<QuizHistoryInformation>();
}

public class QuizHistoryInformation
{
    public Guid QuizInfoUuid { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string CategoryDescription { get; set; }
    public int NumberOfQuestions { get; set; }
    public int CorrectAnswers { get; set; }
    public int Rate { get; set; }
    public string OwnerNickName { get; set; }
    public string ImageUrl { get; set; }
}