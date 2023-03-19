using System;
using System.Collections.Generic;
using QZI.Quizzei.Domain.Abstractions;

namespace QZI.Quizzei.Domain.Domains.Questions.Entities;

public class Question : Entity
{
    public Guid QuestionUuid { get; set; }
    public string Description { get; set; }
    public Guid? QuizInfoUuid { get; set; }
    public ICollection<QuestionOption> Options { get; set; } = new List<QuestionOption>();

    public static Question CreateQuestion(string description, Guid quizInfoUuid)
    {
        return new Question
        {
            Description = description,
            QuizInfoUuid = quizInfoUuid,
            CreatedAt = DateTime.Now,
            CreatedBy = "Admin"
        };
    }
}