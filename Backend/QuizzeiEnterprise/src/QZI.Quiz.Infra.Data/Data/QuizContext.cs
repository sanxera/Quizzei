using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QZI.Quiz.Domain.Quiz.Entities;

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

            base.OnModelCreating(modelBuilder);
        }

        public IQueryable<TEntity> GetDbSetWithIncludes<TEntity, TProperty>(params Expression<Func<TEntity, TProperty>>[]? includes) where TEntity : class where TProperty : class
        {
            IQueryable<TEntity> dbSet = Set<TEntity>();

            return !(includes?.Length > 0) ? dbSet : includes.Aggregate(dbSet, (current, include) => current.Include(include));
        }
    }
}
