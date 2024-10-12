namespace StudentInformationSystem.Entity
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string ParentPhone { get; set; }
        public string EducationLevel { get; set; }
        public char Gender { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime? UnenrollmentDate { get; set; }
        // many to many relation between student and teacher
        public List<StudentTeacher> StudentTeachers { get; } = new List<StudentTeacher>();

        public List<StudentLesson> StudentLessons { get; } = new List<StudentLesson>();





    }
}
