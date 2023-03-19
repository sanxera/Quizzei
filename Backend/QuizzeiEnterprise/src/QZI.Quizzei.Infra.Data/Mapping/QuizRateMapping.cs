using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;

namespace QZI.Quizzei.Infra.Data.Mapping;

public class QuizRateMapping : IEntityTypeConfiguration<QuizRate>
{
    public void Configure(EntityTypeBuilder<QuizRate> builder)
    {
        builder.ToTable("QUIZ_RATE");

        builder.Property(x => x.QuizRateUuid)
            .HasColumnName("QUIZ_RATE_UUID");

        builder.Property(x => x.QuizProcessUuid)
            .HasColumnName("QUIZ_PROCESS_UUID");

        builder.Property(e => e.Rate)
            .HasColumnName("RATE");

        builder.Property(e => e.QuizInformationUuid)
            .HasColumnName("QUIZ_INFO_UUID");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.Property(e => e.CreatedBy)
            .IsRequired()
            .HasColumnName("CREATED_BY");

        builder
            .HasKey(e => e.QuizRateUuid)
            .HasName("QUIZ_RATE_UUID");
    }
}