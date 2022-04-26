using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Quiz.Domain.Quiz.Entities;

namespace QZI.Quiz.Infra.Data.Mappers
{
    public static class QuizInfoMapping
    {
        public static void AddQuizInfoMapping(this ModelBuilder builder)
        {
            builder.Entity<QuizInfo>(entity =>
            {
                entity.ToTable("QUIZ_INFO");

                entity.Property(e => e.QuizInfoUuid)
                    .ValueGeneratedNever()
                    .HasColumnName("QUIZ_UUID");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.Points)
                    .IsRequired()
                    .HasColumnType("int");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CATEGORY_ID");

                entity.HasKey(e => e.QuizInfoUuid)
                    .HasName("QUIZ_UUID");

                entity
                    .HasOne(x => x.Category)
                    .WithMany(y => y.QuizInfo)
                    .HasForeignKey(t => t.CategoryId);
            });
        }
    }
}
