using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace berkeley_college.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Assignment> Assignment { get; set; }
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<ModuleAssignment> ModuleAssignment { get; set; }
        public virtual DbSet<ModuleCourse> ModuleCourse { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<TeacherModule> TeacherModule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User ID=college_admin;Password=9828;Persist Security Info=True");
                */
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "COLLEGE_ADMIN");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("ADDRESS");

                entity.Property(e => e.AddressId)
                    .HasColumnName("ADDRESS_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("CITY")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasColumnName("ZIP")
                    .HasColumnType("NUMBER(38)");
            });

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.ToTable("ASSIGNMENT");

                entity.Property(e => e.AssignmentId)
                    .HasColumnName("ASSIGNMENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId)
                    .IsRequired()
                    .HasColumnName("DEPARTMENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("TYPE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Assignment)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ASSIGNMENT_DEPARTMENT_FK");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ATTENDANCE");

                entity.Property(e => e.AttendanceDate)
                    .HasColumnName("ATTENDANCE_DATE")
                    .HasColumnType("DATE");

                entity.Property(e => e.DepartmentId)
                    .IsRequired()
                    .HasColumnName("DEPARTMENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleId)
                    .IsRequired()
                    .HasColumnName("MODULE_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasColumnName("STUDENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany()
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ATTENDANCE_DEPARTMENT_FK");

                entity.HasOne(d => d.Module)
                    .WithMany()
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ATTENDANCE_MODULE_FK");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ATTENDANCE_STUDENT_FK");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.Property(e => e.CourseId)
                    .HasColumnName("COURSE_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fee)
                    .HasColumnName("FEE")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Years)
                    .HasColumnName("YEARS")
                    .HasColumnType("NUMBER(38)");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("DEPARTMENT");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DEPARTMENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("MODULE");

                entity.Property(e => e.ModuleId)
                    .HasColumnName("MODULE_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Credit)
                    .HasColumnName("CREDIT")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TeachingDays)
                    .HasColumnName("TEACHING_DAYS")
                    .HasColumnType("NUMBER(38)");
            });

            modelBuilder.Entity<ModuleAssignment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MODULE_ASSIGNMENT");

                entity.Property(e => e.AssignmentId)
                    .IsRequired()
                    .HasColumnName("ASSIGNMENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleId)
                    .IsRequired()
                    .HasColumnName("MODULE_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("TYPE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Assignment)
                    .WithMany()
                    .HasForeignKey(d => d.AssignmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MODULE_ASSIGNMENT_FK");

                entity.HasOne(d => d.Module)
                    .WithMany()
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MODULE_ASSIGNMENT_FK1");
            });

            modelBuilder.Entity<ModuleCourse>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MODULE_COURSE");

                entity.Property(e => e.CourseId)
                    .IsRequired()
                    .HasColumnName("COURSE_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleId)
                    .IsRequired()
                    .HasColumnName("MODULE_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MODULE_COURSE_COURSE_FK");

                entity.HasOne(d => d.Module)
                    .WithMany()
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MODULE_COURSE_MODULE_FK");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("PAYMENT");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("PAYMENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("DATE");

                entity.Property(e => e.DepartmentId)
                    .IsRequired()
                    .HasColumnName("DEPARTMENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasColumnName("STUDENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Year)
                    .HasColumnName("YEAR")
                    .HasColumnType("NUMBER(38)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAYMENT_DEPARTMENT_FK");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAYMENT_STUDENT_FK");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("PERSON");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PERSON_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AddressId)
                    .IsRequired()
                    .HasColumnName("ADDRESS_ID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PERSON_ADDRESS_FK");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("RESULT");

                entity.Property(e => e.ResultId)
                    .HasColumnName("RESULT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AssignmentId)
                    .IsRequired()
                    .HasColumnName("ASSIGNMENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasColumnName("GRADE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleId)
                    .IsRequired()
                    .HasColumnName("MODULE_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("STATUS")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasColumnName("STUDENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.AssignmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EXAM_ASSIGNMENT_FK");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EXAM_MODULE_FK");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Result)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EXAM_STUDENT_FK");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.HasIndex(e => e.PersonId)
                    .HasName("STUDENT__UN")
                    .IsUnique();

                entity.Property(e => e.StudentId)
                    .HasColumnName("STUDENT_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CourseId)
                    .IsRequired()
                    .HasColumnName("COURSE_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PersonId)
                    .IsRequired()
                    .HasColumnName("PERSON_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Year)
                    .HasColumnName("YEAR")
                    .HasColumnType("NUMBER(38)");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("STUDENT_COURSE_FK");

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("STUDENT_PERSON_FK");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("TEACHER");

                entity.Property(e => e.TeacherId)
                    .HasColumnName("TEACHER_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PersonId)
                    .IsRequired()
                    .HasColumnName("PERSON_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("SALARY")
                    .HasColumnType("NUMBER(38)");

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Teacher)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TEACHER_PERSON_FK");
            });

            modelBuilder.Entity<TeacherModule>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.ToTable("TEACHER_MODULE");

                entity.Property(e => e.ModuleId)
                    .IsRequired()
                    .HasColumnName("MODULE_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherId)
                    .IsRequired()
                    .HasColumnName("TEACHER_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Module)
                    .WithMany()
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TEACHER_MODULE_MODULE_FK");

                entity.HasOne(d => d.Teacher)
                    .WithMany()
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TEACHER_MODULE_TEACHER_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
