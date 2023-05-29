using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Infra.Data.Mapping;

public class QuestionCategoryMapping : IEntityTypeConfiguration<QuestionCategory>
{
    public void Configure(EntityTypeBuilder<QuestionCategory> builder)
    {
        builder.ToTable("QUESTION_CATEGORY");

        builder.Property(e => e.Id)
            .HasColumnName("QUESTION_CATEGORY_ID");

        builder.Property(e => e.Description)
            .HasColumnName("DESCRIPTION");

        builder.Property(e => e.Active)
            .HasColumnName("ACTIVE");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.Property(e => e.CreatedBy)
            .HasColumnName("CREATED_BY");

        builder
            .HasKey(e => e.Id)
            .HasName("QUESTION_CATEGORY_ID");
    }
}