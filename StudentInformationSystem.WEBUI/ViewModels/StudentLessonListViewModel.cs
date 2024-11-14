using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.ViewModels
{
    public class StudentLessonListViewModel
    {
        public List<Teacher> teachers { get; set; }
        public List<LessonDTO> lessons { get; set; }
        public Student student { get; set; }
    }
}
