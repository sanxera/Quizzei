using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;

namespace QZI.Quizzei.Infra.Data.Mapping;

public class QuizInfoFileMapping : IEntityTypeConfiguration<QuizInformationFile>
{
    public void Configure(EntityTypeBuilder<QuizInformationFile> builder)
    {
        builder.ToTable("QUIZ_INFO_FILES");

        builder.Property(e => e.QuizInfoFileUuid)
            .HasColumnName("QUIZ_INFO_FILES_UUID");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasColumnName("Name");

        builder.Property(e => e.QuizInfoUuid)
            .HasColumnName("QUIZ_INFO_UUID");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.Property(e => e.CreatedBy)
            .IsRequired()
            .HasColumnName("CREATED_BY");

        builder.HasKey(e => e.QuizInfoFileUuid)
            .HasName("QUIZ_INFO_FILES_UUID");
    }
}