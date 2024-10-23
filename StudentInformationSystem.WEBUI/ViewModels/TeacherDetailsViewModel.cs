using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.ViewModels
{
    public class TeacherDetailsViewModel
    {
        public Teacher teacher { get; set; }
        public List<LessonDTO> lessons { get; set; }
        public IFormFile? CVFile { get; set; }
        public IFormFile? ReferenceLetterFile { get; set; }
    }
}
