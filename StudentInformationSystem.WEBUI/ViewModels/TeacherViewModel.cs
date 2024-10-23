using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.ViewModels
{
    public class TeacherViewModel
    {
        public List<Teacher> teachers { get; set; }
        public List<LessonDTO> lessons { get; set; }
    }
}
