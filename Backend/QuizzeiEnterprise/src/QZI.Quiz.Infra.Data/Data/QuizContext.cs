using Microsoft.EntityFrameworkCore;
using QZI.Quiz.Domain.Quiz.Entities;
using QZI.Quiz.Infra.Data.Data.Mappers;

namespace QZI.Quiz.Infra.Data.Data
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> options) : base(options) { }

        public virtual DbSet<QuizInfo> QuizzesInfos { get; set; }
        public virtual DbSet<QuizCategory> QuizCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.AddQuizInfoMapping();
            modelBuilder.AddQuizCategoryMapping();

            base.OnModelCreating(modelBuilder);
        }
    }
}
