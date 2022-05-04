using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Quiz.Domain.Quiz.Entities;

namespace QZI.Quiz.Infra.Data.Data.Mappers
{
    public class QuizCategoryMapping : IEntityTypeConfiguration<QuizCategory>
    {
        public void Configure(EntityTypeBuilder<QuizCategory> builder)
        {
            builder.ToTable("QUIZ_CATEGORY");

            builder.Property(e => e.QuizCategoryId)
                .HasColumnName("CATEGORY_ID");

            builder.Property(e => e.Description)
                .HasColumnName("DESCRIPTION");

            builder.Property(e => e.Active)
                .HasColumnName("ACTIVE");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("CREATED_AT");

            builder.Property(e => e.CreatedBy)
                .HasColumnName("CREATED_BY");

            builder
                .HasKey(e => e.QuizCategoryId)
                .HasName("CATEGORY_ID");
        }
    }
}
