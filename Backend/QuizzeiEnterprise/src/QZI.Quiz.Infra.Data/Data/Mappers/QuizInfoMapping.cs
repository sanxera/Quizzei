using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Quiz.Domain.Quiz.Entities;

namespace QZI.Quiz.Infra.Data.Data.Mappers
{
    public class QuizInfoMapping : IEntityTypeConfiguration<QuizInfo>
    {
        public void Configure(EntityTypeBuilder<QuizInfo> builder)
        {
            builder.ToTable("QUIZ_INFO");

            builder.Property(e => e.QuizInfoUuid)
                .ValueGeneratedNever()
                .HasColumnName("QUIZ_UUID");

            builder.Property(e => e.Active)
                .HasColumnName("ACTIVE");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_AT");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TITLE");

            builder.Property(e => e.Points)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(e => e.CategoryId)
                .HasColumnName("CATEGORY_ID");

            builder.HasKey(e => e.QuizInfoUuid)
                .HasName("QUIZ_UUID");

            builder
                .HasOne(x => x.Category)
                .WithMany(y => y.QuizInfo)
                .HasForeignKey(t => t.CategoryId);
        }
    }
}
