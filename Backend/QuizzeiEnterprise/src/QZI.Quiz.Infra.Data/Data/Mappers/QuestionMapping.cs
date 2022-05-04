using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Quiz.Domain.Quiz.Entities;

namespace QZI.Quiz.Infra.Data.Data.Mappers
{
    public class QuestionMapping : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("QUESTION");

            builder.HasKey(e => e.QuestionUuid)
                .HasName("QUESTION_UUID");

            builder.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("CREATED_AT");

            builder.Property(e => e.CreatedBy)
                .HasColumnName("CREATED_BY");

            builder
                .HasOne(x => x.QuizInfo)
                .WithMany(e => e.Questions)
                .HasForeignKey(x => new
                {
                    QUIZ_UUID = x.QuizInfoUuid
                });

            builder
                .HasMany(x => x.Options)
                .WithOne(f => f.Question)
                .HasForeignKey(e => new
                {
                    QUESTION_UUID = e.QuestionUuid
                });
        }
    }
}
