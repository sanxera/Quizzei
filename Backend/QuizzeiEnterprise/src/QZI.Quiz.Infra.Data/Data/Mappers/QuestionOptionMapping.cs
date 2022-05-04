using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Quiz.Domain.Quiz.Entities;

namespace QZI.Quiz.Infra.Data.Data.Mappers
{
    public class QuestionOptionMapping : IEntityTypeConfiguration<QuestionOption>
    {
        public void Configure(EntityTypeBuilder<QuestionOption> builder)
        {
            builder.ToTable("QUESTION_OPTION");

            builder
                .HasKey(e => e.QuestionOptionUuid)
                .HasName("QUESTION_OPTION_UUID");

            builder
                .Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .IsRequired();

            builder.Property(e => e.IsCorrect)
                .HasColumnName("ISCORRECT")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("CREATED_AT");

            builder.Property(e => e.CreatedBy)
                .HasColumnName("CREATED_BY");
        }
    }
}
