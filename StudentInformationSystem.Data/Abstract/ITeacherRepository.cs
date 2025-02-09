using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Abstract
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        void ConfirmTeacher(Teacher entity);

        void UpdateTeacherScore(Teacher entity);
    }
}
