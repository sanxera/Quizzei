using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;

namespace QZI.Quizzei.Infra.Data.Mapping;

public class QuizInfoMapping : IEntityTypeConfiguration<QuizInformation>
{
    public void Configure(EntityTypeBuilder<QuizInformation> builder)
    {
        builder.ToTable("QUIZ_INFO");

        builder.Property(e => e.QuizInfoUuid)
            .HasColumnName("QUIZ_UUID");

        builder.Property(e => e.Active)
            .HasColumnName("ACTIVE");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.Property(e => e.CreatedBy)
            .IsRequired()
            .HasColumnName("CREATED_BY");

        builder.Property(e => e.Description)
            .IsRequired()
            .HasColumnName("DESCRIPTION");

        builder.Property(e => e.Title)
            .HasColumnName("TITLE")
            .IsRequired();
                
        builder.Property(e => e.Points)
            .HasColumnName("POINTS")
            .IsRequired();

        builder.Property(e => e.UserOwnerId)
            .IsRequired()
            .HasColumnName("USER_UUID");

        builder.Property(e => e.ImageName)
            .HasColumnName("IMAGE_NAME");

        builder.Property(e => e.CategoryId)
            .HasColumnName("CATEGORY_ID");

        builder.HasKey(e => e.QuizInfoUuid)
            .HasName("QUIZ_UUID");

        builder
            .HasMany(x => x.Files)
            .WithOne(f => f.QuizInformation)
            .HasForeignKey(e => new
            {
                QUIZ_INFO_UUID = e.QuizInfoUuid
            });
    }
}