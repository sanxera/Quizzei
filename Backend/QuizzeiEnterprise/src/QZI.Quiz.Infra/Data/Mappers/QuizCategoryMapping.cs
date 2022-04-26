using System;
using Microsoft.EntityFrameworkCore;
using QZI.Quiz.Domain.Quiz.Entities;

namespace QZI.Quiz.Infra.Data.Mappers
{
    public static class QuizCategoryMapping
    {
        public static void AddQuizCategoryMapping(this ModelBuilder builder)
        {
            builder.Entity<QuizCategory>(entity =>
            {
                entity.ToTable("QUIZ_CATEGORY");

                entity.Property(e => e.QuizCategoryId)
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Active)
                    .HasColumnName("ACTIVE");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CREATED_BY");

                entity
                    .HasKey(e => e.QuizCategoryId)
                    .HasName("CATEGORY_ID");
            });
        }
    }
}
