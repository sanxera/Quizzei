using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QZI.Quizzei.Application.Shared.Entities;

namespace QZI.Quizzei.Infra.Data;

public class QuizzeiContext : IdentityDbContext<ApplicationUser>
{
    public QuizzeiContext(DbContextOptions<QuizzeiContext> options) : base(options) { }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<QuestionOption> Options { get; set; }
    public virtual DbSet<Question> Questions { get; set; }
    public virtual DbSet<QuizInformation> QuizzesInfos { get; set; }
    public virtual DbSet<QuizProcess> QuizProcesses { get; set; }
    public virtual DbSet<QuizRate> QuizRates { get; set; }
    public virtual DbSet<Answer> Answers { get; set; }
    public virtual DbSet<QuizInformationFile> QuizInformationFiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
        base.OnModelCreating(modelBuilder);
    }
}