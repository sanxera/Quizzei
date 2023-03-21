using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Infra.Data.Mapping;

public class QuestionOptionMapping : IEntityTypeConfiguration<QuestionOption>
{
    public void Configure(EntityTypeBuilder<QuestionOption> builder)
    {
        builder.ToTable("QUESTION_OPTION");

        builder
            .Property(e => e.QuestionOptionUuid)
            .HasColumnName("QUESTION_OPTIONS_UUID")
            .IsRequired();

        builder
            .Property(e => e.Description)
            .HasColumnName("DESCRIPTION")
            .IsRequired();

        builder
            .Property(e => e.QuestionUuid)
            .HasColumnName("QUESTION_UUID")
            .IsRequired();

        builder.Property(e => e.IsCorrect)
            .HasColumnName("IS_CORRECT")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.Property(e => e.CreatedBy)
            .HasColumnName("CREATED_BY");

        builder
            .HasKey(e => e.QuestionOptionUuid)
            .HasName("QUESTION_OPTIONS_UUID");
    }
}