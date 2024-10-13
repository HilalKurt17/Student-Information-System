using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Entity
{
    public class Assignment
    {
        [Key]
        public int AssignmentID { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public string Explanation { get; set; }
        public int Grade { get; set; }
        public string FailedTopics { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsGraded { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Submitted { get; set; }
        public DateTime DueTime { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }

    }
}
