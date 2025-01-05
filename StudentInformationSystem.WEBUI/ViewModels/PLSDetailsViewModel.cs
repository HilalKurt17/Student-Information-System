using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.ViewModels
{
    public class PLSDetailsViewModel
    {
        public List<Assignment> assignments { get; set; }
        public Student student { get; set; }
        public StudentTeacher privateLesson { get; set; }


    }
}
