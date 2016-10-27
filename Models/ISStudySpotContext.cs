using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ISStudySpot.Models
{
    public partial class ISStudySpotContext : DbContext
    {

        public ISStudySpotContext(DbContextOptions<ISStudySpotContext> options)
        	: base(options)
    	{ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("Accounts_PK");

                entity.Property(e => e.AccountId)
                    .HasColumnName("AccountID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountCreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AccountEmailVerified).HasDefaultValueSql("0");

                entity.Property(e => e.AccountLastLogin)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.AccountPassword).HasMaxLength(255);

                entity.Property(e => e.AccountPasswordTmp).HasMaxLength(255);

                entity.Property(e => e.AccountUpdateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.AccountUserName).HasMaxLength(50);
            });

            modelBuilder.Entity<ClassNoteComments>(entity =>
            {
                entity.HasKey(e => new { e.ClassNoteCommentId, e.TeacherId, e.StudentId, e.ClassNoteId })
                    .HasName("Class_Note_Comments_PK");

                entity.ToTable("Class_Note_Comments");

                entity.HasIndex(e => e.ClassNoteId)
                    .HasName("ClassNoteID");

                entity.HasIndex(e => e.StudentId)
                    .HasName("StudentID");

                entity.HasIndex(e => e.TeacherId)
                    .HasName("TeacherID");

                entity.Property(e => e.ClassNoteCommentId).HasColumnName("ClassNoteCommentID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.ClassNoteId).HasColumnName("ClassNoteID");

                entity.Property(e => e.ClassNoteCommentCreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ClassNoteCommentTitle).HasMaxLength(50);

                entity.Property(e => e.ClassNoteCommentText).HasColumnType("text");

                entity.Property(e => e.ClassNoteCommentUpdateDate)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<ClassNoteSectionTypes>(entity =>
            {
                entity.HasKey(e => e.ClassNoteSectionTypeId)
                    .HasName("Class_Note_Section_Type_PK");

                entity.ToTable("Class_Note_Section_Types");

                entity.Property(e => e.ClassNoteSectionTypeId)
                    .HasColumnName("ClassNoteSectionTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassNoteSectionTypeDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<ClassNoteSections>(entity =>
            {
                entity.HasKey(e => new { e.ClassNoteSectionId, e.ClassId, e.TeacherId, e.StudentId, e.ClassNoteSectionTypeId })
                    .HasName("Class_Note_Sections_PK");

                entity.ToTable("Class_Note_Sections");

                entity.HasIndex(e => e.ClassId)
                    .HasName("ClassID");

                entity.HasIndex(e => e.ClassNoteSectionTypeId)
                    .HasName("ClassNoteSectionTypeID");

                entity.HasIndex(e => e.StudentId)
                    .HasName("StudentID");

                entity.HasIndex(e => e.TeacherId)
                    .HasName("TeacherID");

                entity.Property(e => e.ClassNoteSectionId).HasColumnName("ClassNoteSectionID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.ClassNoteSectionTypeId).HasColumnName("ClassNoteSectionTypeID");

                entity.Property(e => e.ClassNoteSectionCreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ClassNoteSectionTitle).HasMaxLength(50);

                entity.Property(e => e.ClassNoteSectionUpdateDate)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();

                entity.HasOne(d => d.ClassNoteSectionType)
                    .WithMany(p => p.ClassNoteSections)
                    .HasForeignKey(d => d.ClassNoteSectionTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Class_Note_Sections_FK03");
            });

            modelBuilder.Entity<ClassNotes>(entity =>
            {
                entity.HasKey(e => new { e.ClassNoteId, e.ClassNoteSectionId, e.TeacherId, e.StudentId })
                    .HasName("Class_Notes_PK");

                entity.ToTable("Class_Notes");

                entity.HasIndex(e => e.ClassNoteSectionId)
                    .HasName("ClassNoteSectionID");

                entity.HasIndex(e => e.StudentId)
                    .HasName("StudentID");

                entity.HasIndex(e => e.TeacherId)
                    .HasName("TeacherID");

                entity.Property(e => e.ClassNoteId).HasColumnName("ClassNoteID");

                entity.Property(e => e.ClassNoteSectionId).HasColumnName("ClassNoteSectionID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.ClassNoteCreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ClassNoteText).HasColumnType("text");

                entity.Property(e => e.ClassNoteTitle).HasMaxLength(50);

                entity.Property(e => e.ClassNoteUpdateDate)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => new { e.ClassId, e.SubjectId, e.SemesterId, e.TeacherId })
                    .HasName("Classes_PK");

                entity.HasIndex(e => e.ClassId)
                    .HasName("ClassesClasses");

                entity.HasIndex(e => e.SemesterId)
                    .HasName("SemestersClasses");

                entity.HasIndex(e => e.SubjectId)
                    .HasName("SubjectsClasses");

                entity.HasIndex(e => e.TeacherId)
                    .HasName("TeachersClasses");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.SemesterId).HasColumnName("SemesterID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            });

            modelBuilder.Entity<ForgotPasswords>(entity =>
            {
                entity.HasKey(e => e.ForgotPasswordId)
                    .HasName("Forgot_Passwords_PK");

                entity.ToTable("Forgot_Passwords");

                entity.Property(e => e.ForgotPasswordId)
                    .HasColumnName("ForgotPasswordID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ForgotPasswordEmail).HasMaxLength(50);

                entity.Property(e => e.ForgotPasswordTimestamp)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ForgotPasswordTmp).HasMaxLength(255);
            });

            modelBuilder.Entity<LoginAttempts>(entity =>
            {
                entity.HasKey(e => e.LoginAttemptId)
                    .HasName("Login_Attempts_PK");

                entity.ToTable("Login_Attempts");

                entity.Property(e => e.LoginAttemptId)
                    .HasColumnName("LoginAttemptID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LoginAttemptEmail).HasMaxLength(50);

                entity.Property(e => e.LoginAttemptHttpClientIp)
                    .HasColumnName("LoginAttemptHttpClientIP")
                    .HasMaxLength(45);

                entity.Property(e => e.LoginAttemptHttpUserAgent).HasMaxLength(255);

                entity.Property(e => e.LoginAttemptHttpXforwardedFor)
                    .HasColumnName("LoginAttemptHttpXForwardedFor")
                    .HasMaxLength(45);

                entity.Property(e => e.LoginAttemptRemoteAddr).HasMaxLength(45);

                entity.Property(e => e.LoginAttemptTimestamp)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Semesters>(entity =>
            {
                entity.HasKey(e => e.SemesterId)
                    .HasName("Semesters_PK");

                entity.HasIndex(e => e.SemesterName)
                    .HasName("SemesterName")
                    .IsUnique();

                entity.Property(e => e.SemesterId)
                    .HasColumnName("SemesterID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SemesterEndDate).HasColumnType("date");

                entity.Property(e => e.SemesterName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SemesterStartDate).HasColumnType("date");
            });

            modelBuilder.Entity<StudentClassStatus>(entity =>
            {
                entity.HasKey(e => e.ClassStatusId)
                    .HasName("Student_Class_Status_PK");

                entity.ToTable("Student_Class_Status");

                entity.Property(e => e.ClassStatusId)
                    .HasColumnName("ClassStatusID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClassStatusDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<StudentClasses>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.ClassId, e.ClassStatusId })
                    .HasName("Student_Classes_PK");

                entity.ToTable("Student_Classes");

                entity.HasIndex(e => e.ClassId)
                    .HasName("ClassesStudent_Classes");

                entity.HasIndex(e => e.ClassStatusId)
                    .HasName("Student_Class_StatusStudent_Classes");

                entity.HasIndex(e => e.StudentId)
                    .HasName("StudentsStudent_Classes");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.ClassStatusId)
                    .HasColumnName("ClassStatusID")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.AccountId })
                    .HasName("Students_PK");

                entity.HasIndex(e => e.AccountId)
                    .HasName("AccountID");

                entity.HasIndex(e => e.StudAreaCode)
                    .HasName("StudAreaCode");

                entity.HasIndex(e => e.StudZipCode)
                    .HasName("StudZipCode");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.StudAreaCode).HasMaxLength(5);

                entity.Property(e => e.StudBirthDate).HasColumnType("date");

                entity.Property(e => e.StudCity).HasMaxLength(30);

                entity.Property(e => e.StudFirstName).HasMaxLength(25);

                entity.Property(e => e.StudGender).HasMaxLength(1);

                entity.Property(e => e.StudLastName).HasMaxLength(25);

                entity.Property(e => e.StudMaritalStatus).HasMaxLength(1);

                entity.Property(e => e.StudPhoneNumber).HasMaxLength(8);

                entity.Property(e => e.StudState).HasMaxLength(2);

                entity.Property(e => e.StudStreetAddress).HasMaxLength(50);

                entity.Property(e => e.StudZipCode).HasMaxLength(5);
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.SubjectId)
                    .HasName("Subjects_PK");

                entity.HasIndex(e => e.SubjectCode)
                    .HasName("ClassCode")
                    .IsUnique();

                entity.Property(e => e.SubjectId)
                    .HasColumnName("SubjectID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SubjectCode)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.SubjectDescription).HasColumnType("ntext");

                entity.Property(e => e.SubjectName).HasMaxLength(50);
            });

            modelBuilder.Entity<TeacherClasses>(entity =>
            {
                entity.HasKey(e => new { e.ClassId, e.TeacherId })
                    .HasName("Teacher_Classes_PK");

                entity.ToTable("Teacher_Classes");

                entity.HasIndex(e => e.ClassId)
                    .HasName("ClassesTeacherClasses");

                entity.HasIndex(e => e.TeacherId)
                    .HasName("TeachersTeacherClasses");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasKey(e => new { e.TeacherId, e.AccountId })
                    .HasName("Teachers_PK");

                entity.HasIndex(e => e.AccountId)
                    .HasName("AccountID");

                entity.HasIndex(e => e.TeachAreaCode)
                    .HasName("TeachAreaCode");

                entity.HasIndex(e => e.TeachZipCode)
                    .HasName("TeachZipCode");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.TeachAreaCode).HasMaxLength(5);

                entity.Property(e => e.TeachCity).HasMaxLength(30);

                entity.Property(e => e.TeachFirstName).HasMaxLength(25);

                entity.Property(e => e.TeachLastname).HasMaxLength(25);

                entity.Property(e => e.TeachPhoneNumber).HasMaxLength(8);

                entity.Property(e => e.TeachState).HasMaxLength(2);

                entity.Property(e => e.TeachStreetAddress).HasMaxLength(50);

                entity.Property(e => e.TeachZipCode).HasMaxLength(5);
            });
        }
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<ClassNoteComments> ClassNoteComments { get; set; }
        public virtual DbSet<ClassNoteSectionTypes> ClassNoteSectionTypes { get; set; }
        public virtual DbSet<ClassNoteSections> ClassNoteSections { get; set; }
        public virtual DbSet<ClassNotes> ClassNotes { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<ForgotPasswords> ForgotPasswords { get; set; }
        public virtual DbSet<LoginAttempts> LoginAttempts { get; set; }
        public virtual DbSet<Semesters> Semesters { get; set; }
        public virtual DbSet<StudentClassStatus> StudentClassStatus { get; set; }
        public virtual DbSet<StudentClasses> StudentClasses { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<TeacherClasses> TeacherClasses { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<SemesterClasses> SemesterClasses { get; set; }
        public virtual DbSet<ClassInformation> ClassInformation { get; set; }
    }
}