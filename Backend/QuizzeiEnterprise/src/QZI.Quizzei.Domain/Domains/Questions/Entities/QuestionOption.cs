using System;
using System.Collections.Generic;
using System.Linq;
using QZI.Quizzei.Domain.Abstractions;
using QZI.Quizzei.Domain.Domains.Questions.Services.Requests;

namespace QZI.Quizzei.Domain.Domains.Questions.Entities;

public class QuestionOption : Entity
{
    public Guid QuestionOptionUuid { get; set; }
    public string Description { get; set; }
    public bool IsCorrect { get; set; }
    public Guid QuestionUuid { get; set; }
    public Question Question { get; set; }

    public QuestionOption()
    {

    }

    public QuestionOption(string description, bool isCorrect, Guid questionUuid, Question question)
    {
        Description = description;
        IsCorrect = isCorrect;
        QuestionUuid = questionUuid;
        Question = question;
    }

    public static List<QuestionOption> CreateAnyOptions(List<UpdateOptions> questionsRequest)
    {
        return questionsRequest.Select(CreateQuestionOption).ToList();
    }

    private static QuestionOption CreateQuestionOption(UpdateOptions request)
    {
        return new QuestionOption()
        {
            Description = request.Description,
            IsCorrect = request.IsCorrect,
            CreatedAt = DateTime.Now,
            CreatedBy = "Admin"
        };
    }
}