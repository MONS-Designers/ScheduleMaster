using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Entities.Models;
using Task = Entities.Models.Task;

public partial class ScheduleMasterContext : DbContext
{
    public IConfiguration _configuration { get; }
    public ScheduleMasterContext()
    {
    }

    public ScheduleMasterContext(DbContextOptions<ScheduleMasterContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<DiplomaTeacher> DiplomaTeachers { get; set; }

    public virtual DbSet<DiplomaType> DiplomaTypes { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<ManagerTeacher> ManagerTeachers { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<PlacementStatus> PlacementStatuses { get; set; }

    public virtual DbSet<Presence> Presences { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<ScheduleNote> ScheduleNotes { get; set; }

    public virtual DbSet<ScheduleSubject> ScheduleSubjects { get; set; }

    public virtual DbSet<ScheduleType> ScheduleTypes { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<SchoolGroup> SchoolGroups { get; set; }

    public virtual DbSet<SchoolUser> SchoolUsers { get; set; }

    public virtual DbSet<Secretary> Secretaries { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentSubjectAssessment> StudentSubjectAssessments { get; set; }

    public virtual DbSet<StudentSubjectTask> StudentSubjectTasks { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectCategory> SubjectCategories { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskPriority> TaskPriorities { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherConcentraint> TeacherConcentraints { get; set; }

    public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Address_pkey");

            entity.ToTable("Address");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BuildingNumber).HasColumnName("buildingNumber");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.Enterance)
                .HasMaxLength(1)
                .HasColumnName("enterance");
            entity.Property(e => e.Street).HasColumnName("street");
            entity.Property(e => e.ZipCode).HasColumnName("zipCode");
        });

        modelBuilder.Entity<DiplomaTeacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Diploma_Teacher_pkey");

            entity.ToTable("Diploma_Teacher");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DiplomaTypeId).HasColumnName("DiplomaType_id");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.TeacherId).HasColumnName("Teacher_id");

            entity.HasOne(d => d.DiplomaType).WithMany(p => p.DiplomaTeachers)
                .HasForeignKey(d => d.DiplomaTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Diploma_Teacher_DiplomaType_id_fkey");

            entity.HasOne(d => d.Teacher).WithMany(p => p.DiplomaTeachers)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Diploma_Teacher_Teacher_id_fkey");
        });

        modelBuilder.Entity<DiplomaType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("DiplomaType_pkey");

            entity.ToTable("DiplomaType", tb => tb.HasComment("Code table\nBeD, CV etc."));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Manager_pkey");

            entity.ToTable("Manager");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.SchoolUserId).HasColumnName("School_User_id");

            entity.HasOne(d => d.SchoolUser).WithMany(p => p.Managers)
                .HasForeignKey(d => d.SchoolUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Manager_School_User_id_fkey");
        });

        modelBuilder.Entity<ManagerTeacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Manager_Teacher_pkey");

            entity.ToTable("Manager_Teacher");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ManagerId).HasColumnName("Manager_id");
            entity.Property(e => e.TeacherId).HasColumnName("Teacher_id");

            entity.HasOne(d => d.Manager).WithMany(p => p.ManagerTeachers)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Manager_Teacher_Manager_id_fkey");

            entity.HasOne(d => d.Teacher).WithMany(p => p.ManagerTeachers)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Manager_Teacher_Teacher_id_fkey");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Note_pkey");

            entity.ToTable("Note");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
        });

        modelBuilder.Entity<PlacementStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PlacementStatus_pkey");

            entity.ToTable("PlacementStatus", tb => tb.HasComment("Code table"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
        });

        modelBuilder.Entity<Presence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Presence_pkey");

            entity.ToTable("Presence", tb => tb.HasComment("Code table\nנוכחות מלאה, חלקית, חסר"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Schedule_pkey");

            entity.ToTable("Schedule");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DestinationDate).HasColumnName("destinationDate");
            entity.Property(e => e.FromDate).HasColumnName("fromDate");
            entity.Property(e => e.ScheduleTypeId).HasColumnName("ScheduleType_id");
            entity.Property(e => e.SchoolGroupId).HasColumnName("SchoolGroup_id");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.ScheduleType).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.ScheduleTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Schedule_ScheduleType_id_fkey");

            entity.HasOne(d => d.SchoolGroup).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.SchoolGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Schedule_SchoolGroup_id_fkey");
        });

        modelBuilder.Entity<ScheduleNote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Schedule_Note_pkey");

            entity.ToTable("Schedule_Note");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.NoteId).HasColumnName("Note_id");
            entity.Property(e => e.ScheduleId).HasColumnName("Schedule_id");

            entity.HasOne(d => d.Note).WithMany(p => p.ScheduleNotes)
                .HasForeignKey(d => d.NoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Schedule_Note_Note_id_fkey");

            entity.HasOne(d => d.Schedule).WithMany(p => p.ScheduleNotes)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Schedule_Note_Schedule_id_fkey");
        });

        modelBuilder.Entity<ScheduleSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Schedule_Subject_pkey");

            entity.ToTable("Schedule_Subject");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.EndHour).HasColumnName("endHour");
            entity.Property(e => e.PlacementStatusId).HasColumnName("PlacementStatus_id");
            entity.Property(e => e.ScheduleId).HasColumnName("Schedule_id");
            entity.Property(e => e.StartHour).HasColumnName("startHour");
            entity.Property(e => e.SubjectId).HasColumnName("Subject_id");
            entity.Property(e => e.TeacherId).HasColumnName("Teacher_id");

            entity.HasOne(d => d.PlacementStatus).WithMany(p => p.ScheduleSubjects)
                .HasForeignKey(d => d.PlacementStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Schedule_Subject_PlacementStatus_id_fkey");

            entity.HasOne(d => d.Schedule).WithMany(p => p.ScheduleSubjects)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Schedule_Subject_Schedule_id_fkey");

            entity.HasOne(d => d.Subject).WithMany(p => p.ScheduleSubjects)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Schedule_Subject_Subject_id_fkey");

            entity.HasOne(d => d.Teacher).WithMany(p => p.ScheduleSubjects)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Schedule_Subject_Teacher_id_fkey");
        });

        modelBuilder.Entity<ScheduleType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ScheduleType_pkey");

            entity.ToTable("ScheduleType", tb => tb.HasComment("Code table"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("School_pkey");

            entity.ToTable("School");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.AddressId).HasColumnName("Address_id");
            entity.Property(e => e.InstitutionSymbol).HasColumnName("institutionSymbol");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.Schools)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("School_Address_id_fkey");
        });

        modelBuilder.Entity<SchoolGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SchoolGroup_pkey");

            entity.ToTable("SchoolGroup");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.SchoolGroupId).HasColumnName("SchoolGroup_id");
            entity.Property(e => e.SchoolId).HasColumnName("School_id");
            entity.Property(e => e.SubjectCategoryId).HasColumnName("SubjectCategory_id");

            entity.HasOne(d => d.SchoolGroupNavigation).WithMany(p => p.InverseSchoolGroupNavigation)
                .HasForeignKey(d => d.SchoolGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SchoolGroup_fkey");

            entity.HasOne(d => d.School).WithMany(p => p.SchoolGroups)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SchoolGroup_School_id_fkey");

            entity.HasOne(d => d.SubjectCategory).WithMany(p => p.SchoolGroups)
                .HasForeignKey(d => d.SubjectCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SchoolGroup_SubjectCategory_id_fkey");
        });

        modelBuilder.Entity<SchoolUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("School_User_pkey");

            entity.ToTable("School_User");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.SchoolId).HasColumnName("School_id");
            entity.Property(e => e.UserId).HasColumnName("User_id");

            entity.HasOne(d => d.School).WithMany(p => p.SchoolUsers)
                .HasForeignKey(d => d.SchoolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("School_User_School_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.SchoolUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("School_User_User_id_fkey");
        });

        modelBuilder.Entity<Secretary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Secretary_pkey");

            entity.ToTable("Secretary");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.SchoolUserId).HasColumnName("School_User_id");

            entity.HasOne(d => d.SchoolUser).WithMany(p => p.Secretaries)
                .HasForeignKey(d => d.SchoolUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Secretary_School_User_id_fkey");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Student_pkey");

            entity.ToTable("Student");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdNumber).HasColumnName("idNumber");
            entity.Property(e => e.SchoolGroupId).HasColumnName("SchoolGroup_id");
            entity.Property(e => e.SchoolUserId).HasColumnName("School_User_id");

            entity.HasOne(d => d.SchoolGroup).WithMany(p => p.Students)
                .HasForeignKey(d => d.SchoolGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Student_SchoolGroup_id_fkey");

            entity.HasOne(d => d.SchoolUser).WithMany(p => p.Students)
                .HasForeignKey(d => d.SchoolUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Student_School_User_id_fkey");
        });

        modelBuilder.Entity<StudentSubjectAssessment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Student_SubjectAssessment _pkey");

            entity.ToTable("Student_SubjectAssessment ");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Assessment).HasColumnName("assessment");
            entity.Property(e => e.Mark).HasColumnName("mark");
            entity.Property(e => e.PresenceId).HasColumnName("Presence_id");
            entity.Property(e => e.ScheduleSubjectId).HasColumnName("Schedule_Subject_id");
            entity.Property(e => e.StudentId).HasColumnName("Student_id");

            entity.HasOne(d => d.Presence).WithMany(p => p.StudentSubjectAssessments)
                .HasForeignKey(d => d.PresenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Student_SubjectAssessment _Presence_id_fkey");

            entity.HasOne(d => d.ScheduleSubject).WithMany(p => p.StudentSubjectAssessments)
                .HasForeignKey(d => d.ScheduleSubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Student_SubjectAssessment _Schedule_Subject_id_fkey");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentSubjectAssessments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Student_SubjectAssessment _Student_id_fkey");
        });

        modelBuilder.Entity<StudentSubjectTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Student_Subject_Task_pkey");

            entity.ToTable("Student_Subject_Task");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Assessment).HasColumnName("assessment");
            entity.Property(e => e.LinkToSendAnswers).HasColumnName("linkToSendAnswers");
            entity.Property(e => e.Mark).HasColumnName("mark");
            entity.Property(e => e.ScheduleSubjectId).HasColumnName("Schedule_Subject_id");
            entity.Property(e => e.StudentId).HasColumnName("Student_id");
            entity.Property(e => e.TaskId).HasColumnName("Task_id");

            entity.HasOne(d => d.ScheduleSubject).WithMany(p => p.StudentSubjectTasks)
                .HasForeignKey(d => d.ScheduleSubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Student_Subject_Task_Schedule_Subject_id_fkey");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentSubjectTasks)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Student_Subject_Task_Student_id_fkey");

            entity.HasOne(d => d.Task).WithMany(p => p.StudentSubjectTasks)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Student_Subject_Task_Task_id_fkey");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Subject_pkey");

            entity.ToTable("Subject");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.SubjectCategoryId).HasColumnName("SubjectCategory_id");

            entity.HasOne(d => d.SubjectCategory).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.SubjectCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Subject_SubjectCategory_id_fkey");
        });

        modelBuilder.Entity<SubjectCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SubjectCategory_pkey");

            entity.ToTable("SubjectCategory", tb => tb.HasComment("Code table"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Task_pkey");

            entity.ToTable("Task");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasColumnType("time with time zone")
                .HasColumnName("endDate");
            entity.Property(e => e.IsComplete).HasColumnName("isComplete");
            entity.Property(e => e.NoteId).HasColumnName("Note_id");
            entity.Property(e => e.SchoolUserId).HasColumnName("School_User_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("time with time zone")
                .HasColumnName("startDate");
            entity.Property(e => e.TaskPriorityId).HasColumnName("TaskPriority_id");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.Note).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.NoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Task_Note_id_fkey");

            entity.HasOne(d => d.SchoolUser).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.SchoolUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Task_School_User_id_fkey");

            entity.HasOne(d => d.TaskPriority).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TaskPriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Task_TaskPriority_id_fkey");
        });

        modelBuilder.Entity<TaskPriority>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TaskPriority_pkey");

            entity.ToTable("TaskPriority", tb => tb.HasComment("Code table"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Teacher_pkey");

            entity.ToTable("Teacher");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdNumber).HasColumnName("idNumber");
            entity.Property(e => e.SchoolUserId).HasColumnName("School_User_id");

            entity.HasOne(d => d.SchoolUser).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.SchoolUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Teacher_School_User_id_fkey");
        });

        modelBuilder.Entity<TeacherConcentraint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TeacherConcentraint_pkey");

            entity.ToTable("TeacherConcentraint");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DayOfWeek).HasColumnName("dayOfWeek");
            entity.Property(e => e.EndHour).HasColumnName("endHour");
            entity.Property(e => e.IsAble).HasColumnName("isAble");
            entity.Property(e => e.IsRequired).HasColumnName("isRequired");
            entity.Property(e => e.StartHour).HasColumnName("startHour");
            entity.Property(e => e.TeacherId).HasColumnName("Teacher_id");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherConcentraints)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TeacherConcentraint_Teacher_id_fkey");
        });

        modelBuilder.Entity<TeacherSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Teacher_Subject_pkey");

            entity.ToTable("Teacher_Subject");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.NPlacementHours).HasColumnName("nPlacementHours");
            entity.Property(e => e.SubjectId).HasColumnName("Subject_id");
            entity.Property(e => e.TeacherId).HasColumnName("Teacher_id");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Teacher_Subject_Subject_id_fkey");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Teacher_Subject_Teacher_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("User");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("Address_id");
            entity.Property(e => e.FirstName).HasColumnName("firstName");
            entity.Property(e => e.LastName).HasColumnName("lastName");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.ProfileImage).HasColumnName("profileImage");
            entity.Property(e => e.Salt).HasColumnName("salt");
            entity.Property(e => e.UserTypeId).HasColumnName("UserType_id");
            entity.Property(e => e.Username).HasColumnName("username");

            entity.HasOne(d => d.Address).WithMany(p => p.Users)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_Address_id_fkey");

            entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_UserType_id_fkey");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("UserType_pkey");

            entity.ToTable("UserType", tb => tb.HasComment("Code table"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
