using StudentInformationSystem.Entity;

namespace StudentInformationSystem.WEBUI.ViewModels
{
    public class GetScoreCommentPLViewModel
    {
        public int privateLessonID { get; set; }
        public int teacherScore { get; set; }
        public Student student { get; set; }
        public Teacher teacher { get; set; }
    }
}
