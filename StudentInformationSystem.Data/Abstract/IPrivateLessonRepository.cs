using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Abstract
{
    public interface IPrivateLessonRepository : IRepository<StudentTeacher>
    {
        void NewEnrollment(StudentTeacher studentEnrollment);
    }
}
