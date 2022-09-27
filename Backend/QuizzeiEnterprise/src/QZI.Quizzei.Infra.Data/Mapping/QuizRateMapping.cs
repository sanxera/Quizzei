using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QZI.Quizzei.Domain.Domains.Questions.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;

namespace QZI.Quizzei.Infra.Data.Mapping
{
    public class QuizRateMapping : IEntityTypeConfiguration<QuizRate>
    {
        public void Configure(EntityTypeBuilder<QuizRate> builder)
        {
            builder.ToTable("QUIZ_RATE");

            builder.Property(x => x.QuizProcessUuid)
                .HasColumnName("QUIZ_PROCESS_UUID");

            builder.Property(e => e.Rate)
                .HasColumnName("RATE");

            builder.Property(e => e.QuizInformationUuid)
                .HasColumnName("QUIZ_INFO_UUID");
        }
    }
}
