using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Infra.Data.Mapping;

public class QuizAccessMapping : IEntityTypeConfiguration<QuizAccess>
{
    public void Configure(EntityTypeBuilder<QuizAccess> builder)
    {
        builder.ToTable("QUIZ_ACCESS");

        builder.Property(e => e.QuizAccessUuid)
            .HasColumnName("QUIZ_ACCESS_UUID");

        builder.Property(e => e.QuizInfoUuid)
            .HasColumnName("QUIZ_INFO_UUID");

        builder.Property(e => e.InitialDate)
            .HasColumnName("INITIAL_DATE");

        builder.Property(e => e.EndDate)    
            .HasColumnName("END_DATE");

        builder.Property(e => e.AccessCode)
            .HasColumnName("ACCESS_CODE");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.Property(e => e.CreatedBy)
            .IsRequired()
            .HasColumnName("CREATED_BY");

        builder.HasKey(x => x.QuizAccessUuid)
            .HasName("QUIZ_ACCESS_UUID");
    }
}