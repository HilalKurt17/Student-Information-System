namespace StudentInformationSystem.Entity
{
    public class TeacherLesson
    {
        public int TeacherID { get; set; }
        public int LessonID { get; set; }
        public Teacher? Teacher { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
