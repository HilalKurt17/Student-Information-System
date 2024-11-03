using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Entity
{
    public class StudentTeacher
    {
        [Key]
        public int PrivateLessonID { get; set; }
        public int? StudentID { get; set; }
        public int TeacherID { get; set; }
        public string? LessonName { get; set; }
        public string? ELClassification { get; set; }
        public string? LessonMode { get; set; } // online or on-site
        public string LessonDate { get; set; }
        public string LessonStartTime { get; set; }
        public string LessonStartDate { get; set; }
        public string? LessonEndDate { get; set; }
        public string LessonEndTime { get; set; }
        public double LessonPrice { get; set; }
        public string? LessonDetails { get; set; }
        public bool EnrollmentState { get; set; }
        public int? TeacherLessonScore { get; set; }
        public string? StudentTeacherComment { get; set; }
        public bool RemoveLesson { get; set; }
        public Teacher? Teacher { get; set; }
        public Student? Student { get; set; }
    }
}
