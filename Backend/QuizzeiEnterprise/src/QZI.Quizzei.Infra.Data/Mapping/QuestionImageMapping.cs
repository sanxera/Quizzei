using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Infra.Data.Mapping;

public class QuestionImageMapping : IEntityTypeConfiguration<QuestionImage>
{
    public void Configure(EntityTypeBuilder<QuestionImage> builder)
    {
        builder.ToTable("QUESTION_IMAGE");

        builder.Property(e => e.QuestionImageUuid)
            .HasColumnName("QUESTION_IMAGE_UUID");

        builder.Property(e => e.ImageName)
            .IsRequired()
            .HasColumnName("IMAGE_NAME");

        builder.Property(e => e.QuestionUuid)
            .HasColumnName("QUESTION_UUID");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.Property(e => e.CreatedBy)
            .IsRequired()
            .HasColumnName("CREATED_BY");

        builder.HasKey(e => e.QuestionImageUuid)
            .HasName("QUESTION_IMAGE_UUID");
    }
}