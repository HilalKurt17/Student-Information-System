namespace StudentInformationSystem.Entity
{
    public class StudentTeacher
    {
        public int StudentID { get; set; }
        public int TeacherID { get; set; }
        public Teacher? Teacher { get; set; }
        public Student? Student { get; set; }
    }
}
