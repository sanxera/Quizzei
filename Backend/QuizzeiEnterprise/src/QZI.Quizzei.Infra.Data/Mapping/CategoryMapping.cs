using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Quizzei.Domain.Domains.Categories.Entities;

namespace QZI.Quizzei.Infra.Data.Mapping;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("QUIZ_CATEGORY");

        builder.Property(e => e.Id)
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
            .HasKey(e => e.Id)
            .HasName("CATEGORY_ID");
    }
}