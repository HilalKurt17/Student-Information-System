using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.ViewModels
{
    public class AssignmentViewModel
    {
        public Assignment? assignment { get; set; }
        public List<Teacher>? teachers { get; set; }
        public List<Student>? students { get; set; }
        public IFormFile? TeacherAssignmentFile { get; set; }
        public IFormFile? StudentAssignmentFile { get; set; }
    }
}
