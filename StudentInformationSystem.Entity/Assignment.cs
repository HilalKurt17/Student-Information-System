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
        // these parts are assigned as a string for model binding operation. These dates and times will be assigned automatically ---------------------------------------------------------
        public string? CreatedDate { get; set; }
        public string? CreatedTime { get; set; }
        public string? UpdatedDate { get; set; }
        public string? UpdatedTime { get; set; }
        public string? SubmittedDate { get; set; }
        public string? SubmittedTime { get; set; }
        public string? DueDate { get; set; }
        public string? DueTime { get; set; }
        // ----------------------------------------------------------------------------------------
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }

    }
}
