using Microsoft.EntityFrameworkCore;
using QZI.User.Domain.User.Entities;

namespace QZI.User.Infra.Data
{
    public partial class QuizzeiContext : DbContext
    {
        public QuizzeiContext()
        {
        }

        public QuizzeiContext(DbContextOptions<QuizzeiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Classroom> Classrooms { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionOption> QuestionOptions { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<QuizCategory> QuizCategories { get; set; }
        public virtual DbSet<QuizProcess> QuizProcesses { get; set; }
        public virtual DbSet<QuizStatus> QuizStatuses { get; set; }
        public virtual DbSet<Domain.User.Entities.User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=defaultconnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(e => e.AnswerUuid);

                entity.ToTable("ANSWER");

                entity.Property(e => e.AnswerUuid)
                    .ValueGeneratedNever()
                    .HasColumnName("ANSWER_UUID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.QuestionOptionUuid).HasColumnName("QUESTION_OPTION_UUID");

                entity.Property(e => e.UserUuid).HasColumnName("USER_UUID");

                entity.HasOne(d => d.QuestionOptionUu)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionOptionUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QUESTION_ANSWER");

                entity.HasOne(d => d.UserUu)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.UserUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ANSWER");
            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.HasKey(e => e.ClassroomUuid);

                entity.ToTable("CLASSROOM");

                entity.Property(e => e.ClassroomUuid)
                    .ValueGeneratedNever()
                    .HasColumnName("CLASSROOM_UUID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CourseId).HasColumnName("COURSE_ID");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.UserOwnerUuid).HasColumnName("USER_OWNER_UUID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Classrooms)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_COURSE_CLASSROOM");

                entity.HasOne(d => d.UserOwnerUu)
                    .WithMany(p => p.Classrooms)
                    .HasForeignKey(d => d.UserOwnerUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_OWNER");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.Property(e => e.CourseId)
                    .ValueGeneratedNever()
                    .HasColumnName("COURSE_ID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("PERMISSION");

                entity.Property(e => e.PermissionId)
                    .ValueGeneratedNever()
                    .HasColumnName("PERMISSION_ID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("PROFILE");

                entity.Property(e => e.ProfileId)
                    .ValueGeneratedNever()
                    .HasColumnName("PROFILE_ID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.PermissionId).HasColumnName("PERMISSION_ID");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERMISSION_ID");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.QuestionUuid);

                entity.ToTable("QUESTION");

                entity.Property(e => e.QuestionUuid)
                    .ValueGeneratedNever()
                    .HasColumnName("QUESTION_UUID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.QuizUuid).HasColumnName("QUIZ_UUID");

                entity.HasOne(d => d.QuizUu)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QUIZ_QUESTION_UUID");
            });

            modelBuilder.Entity<QuestionOption>(entity =>
            {
                entity.HasKey(e => e.QuestionOptionsUuid);

                entity.ToTable("QUESTION_OPTION");

                entity.Property(e => e.QuestionOptionsUuid)
                    .ValueGeneratedNever()
                    .HasColumnName("QUESTION_OPTIONS_UUID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Iscorrect).HasColumnName("ISCORRECT");

                entity.Property(e => e.QuestionUuid).HasColumnName("QUESTION_UUID");

                entity.HasOne(d => d.QuestionUu)
                    .WithMany(p => p.QuestionOptions)
                    .HasForeignKey(d => d.QuestionUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QUESTION_QUESTION_OPTION_UUID");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.HasKey(e => e.QuizUuid);

                entity.ToTable("QUIZ");

                entity.Property(e => e.QuizUuid)
                    .ValueGeneratedNever()
                    .HasColumnName("QUIZ_UUID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Points).HasColumnName("POINTS");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CATEGORY_ID");
            });

            modelBuilder.Entity<QuizCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("QUIZ_CATEGORY");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");
            });

            modelBuilder.Entity<QuizProcess>(entity =>
            {
                entity.HasKey(e => e.QuizProcessUuid);

                entity.ToTable("QUIZ_PROCESS");

                entity.Property(e => e.QuizProcessUuid)
                    .ValueGeneratedNever()
                    .HasColumnName("QUIZ_PROCESS_UUID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.QuizUuid).HasColumnName("QUIZ_UUID");

                entity.Property(e => e.Status).HasColumnName("STATUS");

                entity.Property(e => e.UserUuid).HasColumnName("USER_UUID");

                entity.HasOne(d => d.QuizUu)
                    .WithMany(p => p.QuizProcesses)
                    .HasForeignKey(d => d.QuizUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QUIZ_QUIZ_PROCESS_UUID");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.QuizProcesses)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STATUS_QUIZ");

                entity.HasOne(d => d.UserUu)
                    .WithMany(p => p.QuizProcesses)
                    .HasForeignKey(d => d.UserUuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_QUIZ_PROCESS_UUID");
            });

            modelBuilder.Entity<QuizStatus>(entity =>
            {
                entity.ToTable("QUIZ_STATUS");

                entity.Property(e => e.QuizStatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("QUIZ_STATUS_ID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");
            });

            modelBuilder.Entity<Domain.User.Entities.User>(entity =>
            {
                entity.HasKey(e => e.UserUuid);

                entity.ToTable("USER");

                entity.Property(e => e.UserUuid)
                    .ValueGeneratedNever()
                    .HasColumnName("USER_UUID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.ProfileId).HasColumnName("PROFILE_ID");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROFILE_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
