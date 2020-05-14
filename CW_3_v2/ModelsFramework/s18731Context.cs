using Microsoft.EntityFrameworkCore;

namespace CW_3_v2.ModelsFramework
{
    public partial class s18731Context : DbContext
    {
        public s18731Context()
        {
        }

        public s18731Context(DbContextOptions<s18731Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Kategoria> Kategoria { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Miasto> Miasto { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<Produkt> Produkt { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Salgrade> Salgrade { get; set; }
        public virtual DbSet<Sprzedaz> Sprzedaz { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studies> Studies { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskType> TaskType { get; set; }
        public virtual DbSet<TeamMember> TeamMember { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DEPT");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Dname)
                    .HasColumnName("DNAME")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Loc)
                    .HasColumnName("LOC")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EMP");

                entity.Property(e => e.Comm).HasColumnName("COMM");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Empno).HasColumnName("EMPNO");

                entity.Property(e => e.Ename)
                    .HasColumnName("ENAME")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("HIREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .HasColumnName("JOB")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Sal).HasColumnName("SAL");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => e.IdEnrollment)
                    .HasName("Enrollment_pk");

                entity.Property(e => e.IdEnrollment).ValueGeneratedNever();

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.IdStudyNavigation)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.IdStudy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Enrollment_Studies");
            });

            modelBuilder.Entity<Kategoria>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("KATEGORIA");

                entity.Property(e => e.IdKategoria).HasColumnName("ID_KATEGORIA");

                entity.Property(e => e.Kategoria1)
                    .IsRequired()
                    .HasColumnName("KATEGORIA")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("KLIENT");

                entity.Property(e => e.IdKlient).HasColumnName("ID_KLIENT");

                entity.Property(e => e.IdMiasto).HasColumnName("ID_MIASTO");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasColumnName("IMIE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasColumnName("NAZWISKO")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Miasto>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MIASTO");

                entity.Property(e => e.IdMiasto).HasColumnName("ID_MIASTO");

                entity.Property(e => e.Miasto1)
                    .IsRequired()
                    .HasColumnName("MIASTO")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PRACOWNIK");

                entity.Property(e => e.IdMiasto).HasColumnName("ID_MIASTO");

                entity.Property(e => e.IdPracownik).HasColumnName("ID_PRACOWNIK");

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasColumnName("IMIE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasColumnName("NAZWISKO")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Produkt>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PRODUKT");

                entity.Property(e => e.Cena).HasColumnName("CENA");

                entity.Property(e => e.IdKategoria).HasColumnName("ID_KATEGORIA");

                entity.Property(e => e.IdProdukt).HasColumnName("ID_PRODUKT");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("NAZWA")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.IdProject)
                    .HasName("Project_pk");

                entity.Property(e => e.Deadline).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Salgrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SALGRADE");

                entity.Property(e => e.Grade).HasColumnName("GRADE");

                entity.Property(e => e.Hisal).HasColumnName("HISAL");

                entity.Property(e => e.Losal).HasColumnName("LOSAL");
            });

            modelBuilder.Entity<Sprzedaz>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SPRZEDAZ");

                entity.Property(e => e.DataSprzedazy)
                    .HasColumnName("DATA_SPRZEDAZY")
                    .HasColumnType("date");

                entity.Property(e => e.IdKlient).HasColumnName("ID_KLIENT");

                entity.Property(e => e.IdPracownik).HasColumnName("ID_PRACOWNIK");

                entity.Property(e => e.IdProdukt).HasColumnName("ID_PRODUKT");

                entity.Property(e => e.IdSprzedaz).HasColumnName("ID_SPRZEDAZ");

                entity.Property(e => e.Ilosc).HasColumnName("ILOSC");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IndexNumber)
                    .HasName("Student_pk");

                entity.Property(e => e.IndexNumber).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdEnrollmentNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.IdEnrollment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_Enrollment");
            });

            modelBuilder.Entity<Studies>(entity =>
            {
                entity.HasKey(e => e.IdStudy)
                    .HasName("Studies_pk");

                entity.Property(e => e.IdStudy).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.IdTask)
                    .HasName("Task_pk");

                entity.Property(e => e.Deadline).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdAssignedToNavigation)
                    .WithMany(p => p.TaskIdAssignedToNavigation)
                    .HasForeignKey(d => d.IdAssignedTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_TeamMember2");

                entity.HasOne(d => d.IdCreatorNavigation)
                    .WithMany(p => p.TaskIdCreatorNavigation)
                    .HasForeignKey(d => d.IdCreator)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_TeamMember1");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_Project");

                entity.HasOne(d => d.IdTaskTypeNavigation)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.IdTaskType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Task_TaskType");
            });

            modelBuilder.Entity<TaskType>(entity =>
            {
                entity.HasKey(e => e.IdTaskType)
                    .HasName("TaskType_pk");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.HasKey(e => e.IdTeamMember)
                    .HasName("TeamMember_pk");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
