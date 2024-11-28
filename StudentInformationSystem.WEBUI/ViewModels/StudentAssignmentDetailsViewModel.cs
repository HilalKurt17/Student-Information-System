using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.ViewModels
{
    public class StudentAssignmentDetailsViewModel
    {
        public Assignment assignment { get; set; }
        public IFormFile? studentAssignmentSolution { get; set; }
        public int studentID { get; set; }
        public List<StudentTeacher> privateLessons { get; set; }
        public List<Teacher> teachers { get; set; }
    }
}
