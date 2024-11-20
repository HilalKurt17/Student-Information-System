using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.ViewModels
{
    public class TeacherAssignmentViewModel
    {
        public Assignment? assignment { get; set; }
        public Teacher? teacher { get; set; }
        public List<Student> students { get; set; }
        public IFormFile? TeacherAssignmentFile { get; set; }
        public bool deleteAssignment { get; set; }
    }
}
