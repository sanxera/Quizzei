using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.ReaderOcr.Worker.Domain.Entities;

namespace QZI.ReaderOcr.Worker.Data.Mappings;

public class QuestionOptionMapping : IEntityTypeConfiguration<OcrQuestionOption>
{
    public void Configure(EntityTypeBuilder<OcrQuestionOption> builder)
    {
        builder.ToTable("ANALYSIS_OCR_QUESTION_OPTION");

        builder
            .Property(e => e.QuestionOptionUuid)
            .HasColumnName("ANALYSIS_OCR_QUESTION_OPTION_UUID")
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