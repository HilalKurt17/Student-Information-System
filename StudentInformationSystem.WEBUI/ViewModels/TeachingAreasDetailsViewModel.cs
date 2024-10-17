using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.ViewModels
{
    public class TeachingAreasDetailsViewModel
    {
        public List<TeacherLesson> teacherLesson { get; set; }
        public List<LessonDTO> lessons { get; set; }
    }
}
