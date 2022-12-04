using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Data.domainModels;

namespace Data.context
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplate { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<EmpDept> EmpDept { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=DESKTOP-86IH6NM\\MSSQLSERVER01;initial catalog=dashboardapp;persist security info=True; Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasKey(e => e.Deptno)
                    .HasName("pk_dept");

                entity.ToTable("dept");

                entity.Property(e => e.Deptno)
                    .HasColumnName("deptno")
                    .ValueGeneratedNever();

                entity.Property(e => e.Dname)
                    .HasColumnName("dname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Loc)
                    .HasColumnName("loc")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmailTemplate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmailBody).IsUnicode(false);

                entity.Property(e => e.EmailSubject)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmailTemplate1)
                    .IsRequired()
                    .HasColumnName("EmailTemplate");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno)
                    .HasName("pk_emp");

                entity.ToTable("emp");

                entity.Property(e => e.Empno)
                    .HasColumnName("empno")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comm).HasColumnName("comm");

                entity.Property(e => e.Deptno).HasColumnName("deptno");

                entity.Property(e => e.Ename)
                    .HasColumnName("ename")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("hiredate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .HasColumnName("job")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mgr).HasColumnName("mgr");

                entity.Property(e => e.Sal).HasColumnName("sal");

                entity.HasOne(d => d.DeptnoNavigation)
                    .WithMany(p => p.Emp)
                    .HasForeignKey(d => d.Deptno)
                    .HasConstraintName("fk_deptno");
            });

            modelBuilder.Entity<EmpDept>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EMP_DEPT");

                entity.Property(e => e.Comm).HasColumnName("comm");

                entity.Property(e => e.DeptDeptno).HasColumnName("DEPT_DEPTNO");

                entity.Property(e => e.Deptno).HasColumnName("deptno");

                entity.Property(e => e.Dname)
                    .HasColumnName("dname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Empno).HasColumnName("empno");

                entity.Property(e => e.Ename)
                    .HasColumnName("ename")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("hiredate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .HasColumnName("job")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Loc)
                    .HasColumnName("loc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mgr).HasColumnName("mgr");

                entity.Property(e => e.Sal).HasColumnName("sal");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.EmpNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Empname).IsUnicode(false);

                entity.Property(e => e.Gender).HasDefaultValueSql("((1))");

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("IPAddress")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.SourceApplicationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SourcePageName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
