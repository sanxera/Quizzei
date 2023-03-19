using System;
using System.Collections.Generic;

namespace QZI.Quizzei.Domain.Domains.Questions.Services.Requests;

public class AnswerQuestionRequest
{
    public IList<AnswersRequest> Answers { get; set; }
}

public class AnswersRequest
{
    public Guid QuestionUuid { get; set; }
    public Guid OptionUuid { get; set; }
}