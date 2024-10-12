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

        public DbSet<StudentTeacher> StudentTeachers { get; set; }
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
            // define relation between teacher and student
            modelBuilder.Entity<StudentTeacher>()
                .HasKey(st => new { st.StudentID, st.TeacherID });

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
        }
    }
}
