using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace QZI.Category.Infra.Data
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options) { }
        public virtual DbSet<Category.Domain.Entities.Category> QuizCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            base.OnModelCreating(modelBuilder);
        }
    }
}
