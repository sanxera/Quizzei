using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Quizzei.Domain.Domains.Questions.Entities;

namespace QZI.Quizzei.Infra.Data.Mapping;

public class AnswerMapping : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable("ANSWER");

        builder.Property(x => x.AnswerUuid)
            .HasColumnName("ANSWER_UUID");

        builder.Property(e => e.UserUuid)
            .HasColumnName("USER_UUID");

        builder.Property(e => e.QuestionUuid)
            .HasColumnName("QUESTION_UUID");

        builder.Property(e => e.QuestionOptionUuid)
            .HasColumnName("QUESTION_OPTION_UUID");

        builder.Property(e => e.QuizProcessUuid)
            .HasColumnName("QUIZ_PROCESS_UUID");

        builder.Property(e => e.CorrectAnswer)
            .HasColumnName("CORRECT_ANSWER");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.Property(e => e.CreatedBy)
            .HasColumnName("CREATED_BY");

        builder.HasKey(x => x.AnswerUuid)
            .HasName("ANSWER_UUID");
    }
}