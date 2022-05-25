using System.Reflection;
using Microsoft.EntityFrameworkCore;
using QZI.Question.Domain.Questions.Entities;

namespace QZI.Question.Infra.Data
{
    public class QuestionContext : DbContext
    {
        public QuestionContext(DbContextOptions<QuestionContext> options) : base(options) { }

        public virtual DbSet<QuestionOption> QuestionOptions { get; set; }
        public virtual DbSet<Domain.Questions.Entities.Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            base.OnModelCreating(modelBuilder);
        }
    }
}
