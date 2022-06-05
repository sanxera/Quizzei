using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Question.Domain.Questions.Entities;

namespace QZI.Question.Infra.Data.Mappers
{
    public class AnswerMapping : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("QUESTION_ANSWER");

            builder.Property(x => x.AnswerUuid)
                .HasColumnName("QUESTION_ANSWER_UUID");

            builder.Property(e => e.UserUuid)
                .HasColumnName("USER_UUID");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("CREATED_AT");

            builder.Property(e => e.CreatedBy)
                .HasColumnName("CREATED_BY");

            builder.HasKey(x => x.AnswerUuid)
                .HasName("QUESTION_ANSWER_UUID");

            builder.HasOne(x => x.QuestionOption);
        }
    }
}
