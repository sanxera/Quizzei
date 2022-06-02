using System.Reflection;
using Microsoft.EntityFrameworkCore;
using QZI.Quiz.Domain.Quiz.Entities;

namespace QZI.Quiz.Infra.Data.Data
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options) { }

        public virtual DbSet<QuizInfo> QuizzesInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            base.OnModelCreating(modelBuilder);
        }
    }
}
