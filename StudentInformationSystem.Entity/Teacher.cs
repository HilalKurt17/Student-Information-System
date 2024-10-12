namespace StudentInformationSystem.Entity
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string EducationLevel { get; set; }
        public char Gender { get; set; }
        public string IBAN { get; set; }
        public int TeacherScore { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime? UnenrollmentDate { get; set; }
        // many to many relation between student and teacher
        public List<StudentTeacher> StudentTeachers { get; } = new List<StudentTeacher>();

        public List<TeacherLesson> TeacherLessons { get; } = new List<TeacherLesson>();
    }
}
