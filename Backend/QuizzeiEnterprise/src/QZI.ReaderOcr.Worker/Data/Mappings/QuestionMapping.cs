using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.ReaderOcr.Worker.Domain.Entities;

namespace QZI.ReaderOcr.Worker.Data.Mappings
{
    public class QuestionMapping : IEntityTypeConfiguration<OcrQuestion>
    {
        public void Configure(EntityTypeBuilder<OcrQuestion> builder)
        {
            builder.ToTable("ANALYSIS_OCR_QUESTION");

            builder.Property(e => e.QuestionUuid)
                .HasColumnName("ANALYSIS_OCR_QUESTION_UUID")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("CREATED_AT");

            builder.Property(e => e.CreatedBy)
                .HasColumnName("CREATED_BY");

            builder.HasKey(e => e.QuestionUuid)
                .HasName("QUESTION_UUID");

            builder
                .HasMany(x => x.Options)
                .WithOne(f => f.Question!)
                .HasForeignKey(e => new
                {
                    QUESTION_UUID = e.QuestionUuid
                });
        }
    }
}
