using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.ViewModels
{
    public class LessonDetailsViewModel
    {
        public List<LessonDTO> allLessons { get; set; }
        public StudentTeacher privateLessonDetails { get; set; }
        public Teacher teacher { get; set; }
    }
}
