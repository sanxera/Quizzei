using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QZI.Question.Infra.Data.Mappers
{
    public class QuestionMapping : IEntityTypeConfiguration<Domain.Questions.Entities.Question>
    {
        public void Configure(EntityTypeBuilder<Domain.Questions.Entities.Question> builder)
        {
            builder.ToTable("QUESTION");

            builder.Property(e => e.QuestionUuid)
                .HasColumnName("QUESTION_UUID")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .IsRequired();

            builder.Property(e => e.QuizInfoUuid)
                .HasColumnName("QUIZ_UUID")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("CREATED_AT");

            builder.Property(e => e.CreatedBy)
                .HasColumnName("CREATED_BY");

            builder.HasKey(e => e.QuestionUuid)
                .HasName("QUESTION_UUID");

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
