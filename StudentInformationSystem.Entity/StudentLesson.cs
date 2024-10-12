namespace StudentInformationSystem.Entity
{
    public class StudentLesson
    {
        public int StudentID { get; set; }
        public int LessonID { get; set; }
        public Student? Student { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
