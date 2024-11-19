using StudentInformationSystem.Entity;

namespace StudentInformationSystem.Data.Abstract
{
    public interface IStudentRepository : IRepository<Student>
    {
        List<Student> GetSelectedStudents(List<int> studentIDs);
    }
}
