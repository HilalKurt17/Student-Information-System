using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.ViewModels
{
    public class TeacherAssignmentListViewModel
    {
        public List<Assignment> assignments { get; set; }
        public List<StudentTeacher> privateLessons { get; set; }
        public List<Student> students { get; set; }
        public int teacherID { get; set; }
    }
}
