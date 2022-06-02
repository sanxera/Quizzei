using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Quiz.Domain.Quiz.Entities;

namespace QZI.Quiz.Infra.Data.Data.Mappers
{
    public class QuizProcessMapping : IEntityTypeConfiguration<QuizProcess>
    {
        public void Configure(EntityTypeBuilder<QuizProcess> builder)
        {
            builder.ToTable("QUIZ_PROCESS");

            builder.Property(e => e.QuizProcessUuid)
                .HasColumnName("QUIZ_PROCESS_UUID");

            builder.Property(e => e.Status)
                .HasColumnName("STATUS");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("CREATED_AT");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("CREATED_BY");

            builder.Property(e => e.UserUuid)
                .IsRequired()
                .HasColumnName("USER_UUID");

            builder.Property(e => e.QuizInfoUuid)
                .IsRequired()
                .HasColumnName("QUIZ_UUID");

            builder
                .HasKey(e => e.QuizProcessUuid)
                .HasName("QUIZ_PROCESS_UUID");
        }
    }
}
