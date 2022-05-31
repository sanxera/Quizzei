using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QZI.Category.Infra.Data.Mapping
{
    public class QuizCategoryMapping : IEntityTypeConfiguration<Domain.Entities.Category>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Category> builder)
        {
            builder.ToTable("QUIZ_CATEGORY");

            builder.Property(e => e.Id)
                .HasColumnName("CATEGORY_ID");

            builder.Property(e => e.Description)
                .HasColumnName("DESCRIPTION");

            builder.Property(e => e.Active)
                .HasColumnName("ACTIVE");

            builder.Property(e => e.CreatedAt)
                .HasColumnName("CREATED_AT");

            builder.Property(e => e.CreatedBy)
                .HasColumnName("CREATED_BY");

            builder
                .HasKey(e => e.Id)
                .HasName("CATEGORY_ID");
        }
    }
}
