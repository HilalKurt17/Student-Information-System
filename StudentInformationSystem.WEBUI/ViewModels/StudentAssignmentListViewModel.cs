using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.ViewModels
{
    public class StudentAssignmentListViewModel
    {
        public List<Assignment> assignments { get; set; }
        public List<Teacher> teachers { get; set; }
        public List<StudentTeacher> privateLessons { get; set; }
        public int StudentID { get; set; }
    }
}
