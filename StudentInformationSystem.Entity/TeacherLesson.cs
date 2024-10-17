using System.Text.Json.Serialization;

namespace StudentInformationSystem.Entity
{
    public class TeacherLesson
    {
        public int TeacherID { get; set; }
        public int LessonID { get; set; }
        public bool IsChecked { get; set; }
        [JsonIgnore]
        public Teacher? Teacher { get; set; }

        [JsonIgnore]
        public Lesson? Lesson { get; set; }
    }
}
