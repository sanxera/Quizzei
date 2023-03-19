using System.Reflection;
using Microsoft.EntityFrameworkCore;
using QZI.ReaderOcr.Worker.Domain.Entities;

namespace QZI.ReaderOcr.Worker.Data;

public class QuizzeiOcrContext : DbContext
{
    public QuizzeiOcrContext(DbContextOptions<QuizzeiOcrContext> options) : base(options) { }

    public virtual DbSet<OcrQuestion>? Questions { get; set; }
    public virtual DbSet<OcrQuestionOption>? Options { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
        base.OnModelCreating(modelBuilder);
    }
}