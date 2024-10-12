namespace StudentInformationSystem.Entity
{
    public class Lesson
    {
        public int LessonID { get; set; }
        public string Name { get; set; }

        public List<StudentLesson> StudentLessons = new List<StudentLesson>();

        public List<TeacherLesson> TeacherLessons = new List<TeacherLesson> { };
    }
}
