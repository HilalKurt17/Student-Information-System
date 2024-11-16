using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Concrete.EfCore
{
    public class SISContext : DbContext
    {
        public SISContext(DbContextOptions<SISContext> options) : base(options) { }
        public SISContext()
        {

        }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Payment> PaymentDetails { get; set; }
        public DbSet<References> TeacherReferences { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Passwords> Passwords { get; set; }


        public DbSet<StudentTeacher> StudentTeachers { get; set; } // used to store private lessons
        public DbSet<StudentLesson> StudentLessons { get; set; }
        public DbSet<TeacherLesson> TeacherLessons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= SISDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   // assign datetime automatically to the enrollmentdate
            modelBuilder.Entity<Student>()
                .Property(s => s.EnrollmentDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Teacher>()
                .Property(t => t.EnrollmentDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            // assign false to the IsApproved 
            modelBuilder.Entity<Teacher>()
                .Property(t => t.IsApproved)
                .HasDefaultValue(false);
            // assign 0 to teacher score 
            modelBuilder.Entity<Teacher>()
                .Property(t => t.TeacherScore)
                .HasDefaultValue(0);
            // assign false to teacher unenrollment state
            modelBuilder.Entity<Teacher>()
                .Property(t => t.UnenrollmentState)
                .HasDefaultValue(false);
            // assign false to student unenrollment state 
            modelBuilder.Entity<Student>()
                .Property(s => s.UnenrollmentState)
                .HasDefaultValue(false);
            // assign false to private lesson(StudentTeachers) remove state
            modelBuilder.Entity<StudentTeacher>()
                .Property(st => st.RemoveLesson)
                .HasDefaultValue(false);
            // define key of passwords
            modelBuilder.Entity<Passwords>()
                .HasKey(p => p.PasswordsID);

            // define relation between teacher and student
            modelBuilder.Entity<StudentTeacher>()
                .HasKey(st => st.PrivateLessonID);

            modelBuilder.Entity<StudentTeacher>()
                .HasIndex(st => new { st.StudentID, st.TeacherID });

            modelBuilder.Entity<StudentTeacher>()
                .HasOne(st => st.Student)
                .WithMany(s => s.StudentTeachers)
                .HasForeignKey(st => st.StudentID);

            modelBuilder.Entity<StudentTeacher>()
                .HasOne(st => st.Teacher)
                .WithMany(t => t.StudentTeachers)
                .HasForeignKey(st => st.TeacherID);
            // define relation between teacher and lesson
            modelBuilder.Entity<TeacherLesson>()
                .HasKey(tl => new { tl.TeacherID, tl.LessonID });

            modelBuilder.Entity<TeacherLesson>()
                .HasOne(tl => tl.Teacher)
                .WithMany(l => l.TeacherLessons)
                .HasForeignKey(tl => tl.TeacherID);

            modelBuilder.Entity<TeacherLesson>()
                .HasOne(tl => tl.Lesson)
                .WithMany(t => t.TeacherLessons)
                .HasForeignKey(tl => tl.LessonID);
            // define relation between student and lesson
            modelBuilder.Entity<StudentLesson>()
                .HasKey(sl => new { sl.StudentID, sl.LessonID });

            modelBuilder.Entity<StudentLesson>()
                .HasOne(sl => sl.Student)
                .WithMany(l => l.StudentLessons)
                .HasForeignKey(sl => sl.StudentID);

            modelBuilder.Entity<StudentLesson>()
                .HasOne(sl => sl.Lesson)
                .WithMany(s => s.StudentLessons)
                .HasForeignKey(sl => sl.LessonID);

            // define relation between student and address
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Address)
                .WithOne(s => s.Student)
                .HasForeignKey<Student>(s => s.StudentID);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Student)
                .WithOne(a => a.Address)
                .HasForeignKey<Address>(a => a.StudentID);
            // define relation between student and payment details
            modelBuilder.Entity<Student>()
                .HasOne(s => s.PaymentDetails)
                .WithOne(s => s.Student)
                .HasForeignKey<Student>(s => s.StudentID);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Student)
                .WithOne(p => p.PaymentDetails)
                .HasForeignKey<Payment>(p => p.StudentID);
            // define relation between student and assignments
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Assignments)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentID);

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Student)
                .WithMany(a => a.Assignments)
                .HasForeignKey(a => a.StudentID);
            // define relation between teacher and references
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.References)
                .WithOne(t => t.Teacher)
                .HasForeignKey(t => t.TeacherID);

            modelBuilder.Entity<References>()
                .HasOne(r => r.Teacher)
                .WithMany(r => r.References)
                .HasForeignKey(r => r.TeacherID);
            // define relation between teacher and work experience
            modelBuilder.Entity<Teacher>()
                .HasMany(s => s.WorkExperiences)
                .WithOne(s => s.Teacher)
                .HasForeignKey(s => s.TeacherID);

            modelBuilder.Entity<WorkExperience>()
                .HasOne(a => a.Teacher)
                .WithMany(a => a.WorkExperiences)
                .HasForeignKey(a => a.TeacherID);
            // define relation between teacher and assignment
            modelBuilder.Entity<Teacher>()
                .HasMany(s => s.Assignments)
                .WithOne(s => s.Teacher)
                .HasForeignKey(s => s.TeacherID);

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Teacher)
                .WithMany(a => a.Assignments)
                .HasForeignKey(a => a.TeacherID);
        }
    }
}
